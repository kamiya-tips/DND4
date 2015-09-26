using UnityEngine;
using System.Collections;

public class ActionMenuButton : MonoBehaviour
{
	public UIButton button;
	public UILabel label;

	public void Init (ActionMenuItem item)
	{
		label.text = item.Name;
		button.enabled = item.Enable;
		EventDelegate.Add (button.onClick, item.OnClick);
	}
}
