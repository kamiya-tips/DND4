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
	#region IMap implementation
	
	public void LookAtPos (VectorInt2 pos, EventDelegate.Callback callback)
	{
		tween.from = mapRoot.localPosition;
		tween.to = new Vector3 (-pos.X * 100 + Screen.width / 2 - 50, -pos.Y * 100 + Screen.height / 2 - 50);
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

	public void ShowMoveArea (GameUnit moveUnit)
	{
		for (int i = -moveUnit.Template.Speed; i <= moveUnit.Template.Speed; i++) {
			for (int j = -moveUnit.Template.Speed; j <= moveUnit.Template.Speed; j++) {
				if (i == 0 && j == 0) {
					continue;
				}
				GameObject tile = GameObject.Instantiate (moveTile);
				tile.transform.parent = mapRoot;
				moveTileList.Add (tile);
				tile.transform.localPosition = Vector3.zero;
				tile.transform.localScale = Vector3.one;
				tile.transform.localPosition = new Vector3 ((moveUnit.X + i) * 100, (moveUnit.Y + j) * 100);
			}
		}
	}

	#endregion
}
