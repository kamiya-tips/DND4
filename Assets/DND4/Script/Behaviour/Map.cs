using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map :MonoBehaviour, IMap
{
	public TweenPosition tween;	
	public Transform mapRoot;
	public GameObject unitToken;
	public GameObject moveTile;
	private List<GameObject> moveTileList = new List<GameObject> ();
	private int mapH = 21;
	private int mapW = 30;
	private int tileSize = 100;
	#region IMap implementation
	
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

	public void ShowRunArea (GameUnit moveUnit)
	{
		Area (moveUnit.X, moveUnit.Y, moveUnit.Template.Speed + 2);
	}

	public void ShowShiftArea (GameUnit moveUnit)
	{
		Area (moveUnit.X, moveUnit.Y, 1);
	}

	public void ShowMoveArea (GameUnit moveUnit)
	{
		Area (moveUnit.X, moveUnit.Y, moveUnit.Template.Speed);
	}

	private void Area (int x, int y, int range)
	{
		for (int i = -range; i <= range; i++) {
			for (int j = -range; j <= range; j++) {
				if (x + i < 0 || y + j < 0) {
					continue;
				}
				if (x + i >= mapW || y + j >= mapH) {
					continue;
				}
				if (GameWorld.Instance.Encounter.IsEmpty (x + i, y + j) == false) {
					continue;
				}
				GameObject tile = GameObject.Instantiate (moveTile);
				tile.transform.parent = mapRoot;
				moveTileList.Add (tile);
				tile.transform.localPosition = Vector3.zero;
				tile.transform.localScale = Vector3.one;
				tile.transform.localPosition = new Vector3 ((x + i) * tileSize, (y + j) * tileSize);
			}
		}
	}

	public void HideArea ()
	{
		for (int i = 0; i < moveTileList.Count; i++) {
			GameObject.Destroy (moveTileList [i]);
		}
		moveTileList.Clear ();
	}

	#endregion
}
