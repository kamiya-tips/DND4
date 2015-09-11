using UnityEngine;
using System.Collections;

public class ActionMenuItem
{
	private bool enable;	

	public bool Enable {
		get {
			return enable;
		}
		set {
			enable = value;
		}
	}

	private string name;

	public string Name {
		get {
			return name;
		}
		set {
			name = value;
		}
	}

	private EventDelegate.Callback onClick;

	public EventDelegate.Callback OnClick {
		get {
			return onClick;
		}
		set {
			onClick = value;
		}
	}
}
