using UnityEngine;
using System.Collections;

public class HpPopup : MonoBehaviour
{
	public UILabel hpLabel;
	public GameObject hpObject;
	public TweenPosition tweenPos;

	public void ShowDamage (int hp, EventDelegate.Callback callback)
	{
		ShowHp (string.Format ("[FF0000]-{0}[-]", hp), callback);
	}

	public void ShowHeal (int hp, EventDelegate.Callback callback)
	{
		ShowHp (string.Format ("[00FF00]+{0}[-]", hp), callback);
	}

	private void ShowHp (string hp, EventDelegate.Callback callback)
	{
		hpLabel.text = hp;
		hpObject.SetActive (true);
		EventDelegate.Add (tweenPos.onFinished, callback, true);
		tweenPos.ResetToBeginning ();
		tweenPos.PlayForward ();
	}

	public void Hide ()
	{
		hpObject.SetActive (false);
	}
}
