using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMenu : MonoBehaviour,IActionMenu
{
	public UISprite bgSprite;
	public GameObject buttonObj;

	#region IActionMenu implementation
	public void Show (List<ActionMenuItem> actionMenuItemList)
	{
		for (int i = 0; i < actionMenuItemList.Count; i++) {
			ActionMenuItem item = actionMenuItemList [i];
			GameObject newButton = GameObject.Instantiate (buttonObj);
			newButton.transform.parent = bgSprite.transform;
			newButton.GetComponent<ActionMenuButton> ().Init (item);
		}
		bgSprite.gameObject.SetActive (true);
	}
	public void Hide ()
	{
		bgSprite.gameObject.SetActive (false);
	}
	#endregion
	
}
