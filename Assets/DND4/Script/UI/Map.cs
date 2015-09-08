using UnityEngine;
using System.Collections;

public class Map : IMap
{
	private TweenPosition tween;	
	private Transform mapRoot;
	private GameObject unitToken;

	public void Init (TweenPosition tween, Transform mapRoot, GameObject unitToken)
	{
		this.tween = tween;
		this.mapRoot = mapRoot;
		this.unitToken = unitToken;
	}

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
	
	#endregion
}
