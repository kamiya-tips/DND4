using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InitiativeQueue : MonoBehaviour,IInitiativeQueue
{
	private const int TOKEN_SIZE = 50;
	private Vector3 startPos;
	private int startDepth = 20;
	private float baseTop;
	private List<TweenPosition> tweenPosList = new List<TweenPosition> ();

	void Awake ()
	{
		startPos = new Vector3 (0, -(TOKEN_SIZE / 2));
		baseTop = Screen.height / 2 - (TOKEN_SIZE / 2);
	}

	#region IInitiativeQueue implementation
	public void AddNewUnit (GameUnit unit)
	{
		//initiativeQueue token
		GameObject unitObject = GameObject.Instantiate (unit.UnitObject);
		unitObject.transform.parent = transform;
		unitObject.transform.localScale = Vector3.one;
		unitObject.transform.localPosition = startPos;
		UISprite uiSprite = unitObject.GetComponent<UISprite> ();
		uiSprite.depth = startDepth - tweenPosList.Count;
		uiSprite.height = TOKEN_SIZE;
		uiSprite.width = TOKEN_SIZE;
		TweenPosition tweenPos = unitObject.GetComponent<TweenPosition> ();
		tweenPosList.Add (tweenPos);
		tweenPos.from = startPos;
		float toY = baseTop - TOKEN_SIZE * tweenPosList.Count;
		float maskHeight = 0.0f;
		if (toY < 0.0f) {
			maskHeight = -toY;
			toY = 0.0f;
		}
		tweenPos.to = new Vector3 (0, toY);
		tweenPos.ResetToBeginning ();
		tweenPos.PlayForward ();
		if (maskHeight > 0.0f) {
			int size = (1 + tweenPosList.Count - 1) * (tweenPosList.Count - 1) / 2;
			float step = maskHeight / size;
			int stepCount = 0;
			for (int i = 1; i < tweenPosList.Count-1; i++) {
				stepCount += i;
				float go = step * stepCount;
				TweenPosition temp = tweenPosList [i];
				temp.from = temp.gameObject.transform.localPosition;
				temp.to = new Vector3 (temp.from.x, baseTop - TOKEN_SIZE * (i + 1) + go, temp.from.z);
				temp.ResetToBeginning ();
				temp.PlayForward ();
			}
		}
	}
	#endregion
}
