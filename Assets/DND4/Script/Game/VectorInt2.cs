using UnityEngine;
using System.Collections;

public class VectorInt2
{
	public VectorInt2 (int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	private int x;

	public int X {
		get {
			return x;
		}
		set {
			x = value;
		}
	}

	private int y;

	public int Y {
		get {
			return y;
		}
		set {
			y = value;
		}
	}
}
