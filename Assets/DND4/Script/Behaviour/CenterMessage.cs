using UnityEngine;
using System.Collections;

public class CenterMessage :MonoBehaviour,IMessage
{
	public UILabel messageLabel;
	public UITweener messageTweener;

	#region IMessage implementation
	public void ShowMessage (string msg, EventDelegate.Callback callback)
	{
		messageLabel.text = msg;
		messageTweener.ResetToBeginning ();
		EventDelegate.Add (messageTweener.onFinished, callback, true);
		messageTweener.PlayForward ();
	}
	#endregion
}
