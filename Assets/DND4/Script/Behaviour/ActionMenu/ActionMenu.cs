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
	private float tileSize = 100.0f;
	public void Awake ()
	{
		buttonPos = new int[4][];
		buttonPos [0] = new int[]{0};
		buttonPos [1] = new int[]{13,-13};
		buttonPos [2] = new int[]{30,0,-30};
		buttonPos [3] = new int[]{45,15,-15,-45};
	}

	#region IActionMenu implementation

	public void Show (int x, int y, List<ActionMenuItem> actionMenuItemList)
	{
		Hide ();
		for (int i = 0; i < buttonList.Count; i++) {
			GameObject.Destroy (buttonList [i]);
		}
		buttonList.Clear ();
		bgSprite.height = MEUN_HEIGHT * actionMenuItemList.Count - 20;
		for (int i = 0; i < actionMenuItemList.Count; i++) {
			ActionMenuItem item = actionMenuItemList [i];
			GameObject newButton = GameObject.Instantiate (buttonObj);
			newButton.transform.parent = bgSprite.transform;
			newButton.GetComponent<ActionMenuButton> ().Init (item);
			newButton.transform.localScale = Vector3.one;
			newButton.transform.localPosition = new Vector3 (0, buttonPos [actionMenuItemList.Count - 1] [i]);
			newButton.SetActive (true);
			newButton.GetComponent<UIButton> ().isEnabled = item.Enable;
			buttonList.Add (newButton);
		}
		bgSprite.gameObject.transform.localPosition = new Vector3 (x * tileSize, y * tileSize);
		bgSprite.gameObject.SetActive (true);
	}

	public void Show (List<ActionMenuItem> actionMenuItemList)
	{
		Show (1, 0, actionMenuItemList);
	}
	public void Hide ()
	{
		bgSprite.gameObject.SetActive (false);
	}
	#endregion
	
}
