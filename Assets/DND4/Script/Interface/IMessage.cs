using UnityEngine;
using System.Collections;

public interface IMessage
{
	void ShowMessage (string msg, EventDelegate.Callback callback);
}
