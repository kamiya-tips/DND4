using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map :MonoBehaviour
{
	public TweenPosition tween;	
	public Transform mapRoot;
	public GameObject unitToken;
	public GameObject moveTile;
	public GameObject stepLable;
	public int tileSize = 100;
	private int mapH = 21;
	private int mapW = 30;
	private GameUnit moveGameUnit;

	public void Awake ()
	{
		UIEventListener.Get (mapRoot.gameObject).onClick = HideMenu;
		UIEventListener.Get (mapRoot.gameObject).onDragStart += HideMenu;
	}

	private void HideMenu (GameObject sender)
	{
		GameWorld.Instance.actionMenu.Hide ();
	}

	public GameUnit MoveGameUnit {
		set {
			moveGameUnit = value;
		}
	}
	
	public void LookAtPos (VectorInt2 pos, EventDelegate.Callback callback)
	{
		tween.from = mapRoot.localPosition;
		tween.to = new Vector3 (-pos.X * tileSize + Screen.width / 2 - tileSize / 2, -pos.Y * tileSize + Screen.height / 2 - tileSize / 2);
		EventDelegate.Add (tween.onFinished, callback, true);
		tween.ResetToBeginning ();
		tween.PlayForward ();
	}

	public void AddGameUnit (GameUnit newUnit)
	{
		GameObject unitObject = GameObject.Instantiate (unitToken);
		unitObject.transform.parent = mapRoot;
		newUnit.UnitObject = unitObject;
		newUnit.UnitObject.SetActive (false);
	}
	
	private List<GameObject> moveTileList = new List<GameObject> ();
	public void ShowMoveArea (int x, int y, int size)
	{
		HideArea ();
		for (int i = -size; i <= size; i++) {
			for (int j = -size; j <= size; j++) {
				if (x + i < 0 || y + j < 0) {
					continue;
				}
				if (x + i >= mapW || y + j >= mapH) {
					continue;
				}
				if (GameWorld.Instance.Encounter.IsEmpty (x + i, y + j) == false) {
					continue;
				}
				if (i == 0 && j == 0) {
					continue;
				}
				GameObject tile = GameObject.Instantiate (moveTile);
				tile.transform.parent = mapRoot;
				moveTileList.Add (tile);
				tile.transform.localPosition = Vector3.zero;
				tile.transform.localScale = Vector3.one;
				tile.transform.localPosition = new Vector3 ((x + i) * tileSize, (y + j) * tileSize);
				MoveTile moveTileBehaviour = tile.GetComponent<MoveTile> ();
				moveTileBehaviour.x = x;
				moveTileBehaviour.y = y;
				moveTileBehaviour.deltaX = i;
				moveTileBehaviour.deltaY = j;
				UIEventListener.Get (tile).onClick = moveGameUnit.MoveTileOnClick;
			}
		}
	}

	public void HideArea ()
	{
		ClearList (moveTileList);
	}

	private List<GameObject> stepListLabel = new List<GameObject> ();

	public void ShowStep (List<VectorInt2> stepList)
	{
		HideStep ();
		for (int i = 0; i < stepList.Count; i++) {
			GameObject stepTemp = GameObject.Instantiate (stepLable);
			stepTemp.transform.parent = mapRoot;
			stepListLabel.Add (stepTemp);
			stepTemp.transform.localPosition = Vector3.zero;
			stepTemp.transform.localScale = Vector3.one;
			stepTemp.transform.localPosition = new Vector3 (stepList [i].X * 100 + 50, stepList [i].Y * 100 + 50);
			stepTemp.GetComponent<UILabel> ().text = (i + 1).ToString ();
		}
	}

	public void HideStep ()
	{
		ClearList (stepListLabel);
	}

	private List<GameObject> attackTileList = new List<GameObject> ();
	public void ShowAttackArea (int x, int y, int size)
	{
		HideAttackArea ();
		for (int i = -size; i <= size; i++) {
			for (int j = -size; j <= size; j++) {
				if (x + i < 0 || y + j < 0) {
					continue;
				}
				if (x + i >= mapW || y + j >= mapH) {
					continue;
				}
				if (i == 0 && j == 0) {
					continue;
				}
				GameObject tile = GameObject.Instantiate (moveTile);
				tile.transform.parent = mapRoot;
				attackTileList.Add (tile);
				tile.transform.localPosition = Vector3.zero;
				tile.transform.localScale = Vector3.one;
				tile.transform.localPosition = new Vector3 ((x + i) * tileSize, (y + j) * tileSize);
				tile.GetComponent<Collider> ().enabled = false;
				tile.GetComponent<UISprite> ().color = Color.red;
			}
		}
	}

	public void HideAttackArea ()
	{
		ClearList (attackTileList);
	}

	private void ClearList (List<GameObject> tempList)
	{
		for (int i = 0; i < tempList.Count; i++) {
			GameObject.Destroy (tempList [i]);
		}
		tempList.Clear ();
	}
}
