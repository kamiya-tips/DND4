using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IActionMenu
{
	void Show (List<ActionMenuItem> actionMenuItemList);
	void Hide ();
}
