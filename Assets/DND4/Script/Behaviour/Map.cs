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
				if (i == 0 && j == 0) {
					continue;
				}
				GameObject tile = GameObject.Instantiate (moveTile);
				tile.transform.parent = mapRoot;
				moveTileList.Add (tile);
				tile.transform.localPosition = Vector3.zero;
				tile.transform.localScale = Vector3.one;
				tile.transform.localPosition = new Vector3 ((x + i) * 100, (y + j) * 100);
			}
		}
	}

	#endregion
}
