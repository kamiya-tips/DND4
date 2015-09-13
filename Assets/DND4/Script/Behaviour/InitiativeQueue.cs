using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InitiativeQueue : MonoBehaviour, IInitiativeQueue
{
	public Transform initRoot;
	private const int TOKEN_SIZE = 50;
	private Vector3 startPos;
	private int startDepth = 20;
	private float baseTop;
	private List<GameUnit> unitList = new List<GameUnit> ();

	public void Awake ()
	{
		startPos = new Vector3 (0, -(TOKEN_SIZE / 2));
		baseTop = Screen.height / 2 - (TOKEN_SIZE / 2);
	}

	#region IInitiativeQueue implementation

	public void UnitStartTurn ()
	{

	}

	public void UnitEndTurn ()
	{

	}

	public void AddNewUnit (GameUnit unit)
	{
		unitList.Add (unit);
		//initiativeQueue token
		GameObject unitObject = GameObject.Instantiate (unit.UnitObject);
		unit.InitObject = unitObject;
		unitObject.transform.parent = this.initRoot;
		unitObject.transform.localScale = Vector3.one;
		unitObject.transform.localPosition = startPos;
		UISprite uiSprite = unitObject.GetComponent<UISprite> ();
		uiSprite.depth = startDepth - unitList.Count;
		uiSprite.height = TOKEN_SIZE;
		uiSprite.width = TOKEN_SIZE;
		TweenPosition tweenPos = unitObject.GetComponent<TweenPosition> ();
		tweenPos.from = startPos;
		float toY = baseTop - TOKEN_SIZE * unitList.Count;
		float maskHeight = 0.0f;
		if (toY < 0.0f) {
			maskHeight = -toY;
			toY = 0.0f;
		}
		tweenPos.to = new Vector3 (0, toY);
		tweenPos.ResetToBeginning ();
		tweenPos.PlayForward ();
		PlayInitToken (maskHeight, 1);
	}

	private void PlayInitToken (float maskHeight, int index)
	{
		if (maskHeight > 0.0f) {
			int size = (1 + unitList.Count - 1) * (unitList.Count - 1) / 2;
			float step = maskHeight / size;
			int stepCount = 0;
			for (int i = index; i < unitList.Count; i++) {
				stepCount += i;
				float go = step * stepCount;
				TweenPosition temp = unitList [i].InitObject.GetComponent<TweenPosition> ();
				temp.from = temp.gameObject.transform.localPosition;
				temp.to = new Vector3 (temp.from.x, baseTop - TOKEN_SIZE * (i + 1) + go, temp.from.z);
				temp.ResetToBeginning ();
				temp.PlayForward ();
			}
		}
	}

	public void SortInitiative ()
	{
		unitList.Sort (new InitiativeComparer ());
		for (int i = 0; i < unitList.Count; i++) {
			unitList [i].InitObject.GetComponent<UISprite> ().depth = startDepth - i;
		}
		float toY = baseTop - TOKEN_SIZE * unitList.Count;
		float maskHeight = 0.0f;
		if (toY < 0.0f) {
			maskHeight = -toY;
		}
		PlayInitToken (maskHeight, 0);
	}
	#endregion
}
