using UnityEngine;
using System.Collections;

public class CenterMessage : IMessage
{
	private UILabel messageLabel;
	private UITweener messageTweener;

	public void Init (UILabel messageLabel, UITweener messageTweener)
	{ 
		this.messageLabel = messageLabel;
		this.messageTweener = messageTweener;
	}

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
