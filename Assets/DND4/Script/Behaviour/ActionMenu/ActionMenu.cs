using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMenu : MonoBehaviour,IActionMenu
{
	public UISprite bgSprite;
	public GameObject buttonObj;
	private int MEUN_HEIGHT = 40;
	private List<GameObject> buttonList = new List<GameObject> ();
	private int[][] buttonPos;

	public void Awake ()
	{
		buttonPos = new int[2][];
		buttonPos [0] = new int[]{0};
		buttonPos [1] = new int[]{15,-15};
	}

	#region IActionMenu implementation
	public void Show (List<ActionMenuItem> actionMenuItemList)
	{
		for (int i = 0; i < buttonList.Count; i++) {
			GameObject.Destroy (buttonList [i]);
		}
		buttonList.Clear ();
		bgSprite.height = MEUN_HEIGHT * actionMenuItemList.Count;
		for (int i = 0; i < actionMenuItemList.Count; i++) {
			ActionMenuItem item = actionMenuItemList [i];
			GameObject newButton = GameObject.Instantiate (buttonObj);
			newButton.transform.parent = bgSprite.transform;
			newButton.GetComponent<ActionMenuButton> ().Init (item);
			newButton.transform.localScale = Vector3.one;
			newButton.transform.localPosition = new Vector3 (0, buttonPos [actionMenuItemList.Count - 1] [i]);
			newButton.SetActive (item.Enable);
			buttonList.Add (newButton);
		}
		bgSprite.gameObject.SetActive (true);
	}
	public void Hide ()
	{
		bgSprite.gameObject.SetActive (false);
	}
	#endregion
	
}
