using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IActionMenu
{
	void Show (List<ActionMenuItem> actionMenuItemList);
	void Show (int x, int y, List<ActionMenuItem> actionMenuItemList);
	void Hide ();
}
