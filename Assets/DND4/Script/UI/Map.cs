using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour,IMap
{
	private TweenPosition tween;	
	public GameObject unitToken;

	void Awake ()
	{
		tween = GetComponent<TweenPosition> ();
	}

	#region IMap implementation
	
	public void LookAtPos (VectorInt2 pos, EventDelegate.Callback callback)
	{
		tween.from = transform.localPosition;
		tween.to = new Vector3 (-pos.X * 100 + Screen.width / 2 - 50, -pos.Y * 100 + Screen.height / 2 - 50);
		EventDelegate.Add (tween.onFinished, callback, true);
		tween.ResetToBeginning ();
		tween.PlayForward ();
	}

	public void AddGameUnit (GameUnit newUnit)
	{
		GameObject unitObject = GameObject.Instantiate (unitToken);
		unitObject.transform.parent = transform;
		newUnit.UnitObject = unitObject;
		newUnit.UnitObject.SetActive (false);
	}
	
	#endregion
}
