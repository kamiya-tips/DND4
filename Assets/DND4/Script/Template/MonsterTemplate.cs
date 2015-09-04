using UnityEngine;
using System.Collections;

public class MonsterTemplate : MonoBehaviour
{
	[SerializeField]
	private int
		lv;

	public int Lv {
		get {
			return lv;
		}
		set {
			lv = value;
		}
	}

	[SerializeField]
	private int
		initiative;

	public int Initiative {
		get {
			return initiative;
		}
		set {
			initiative = value;
		}
	}

	[SerializeField]
	private int
		maxHp;

	public int MaxHp {
		get {
			return maxHp;
		}
		set {
			maxHp = value;
		}
	}
	
	[SerializeField]
	private int[]
		defValue = new int[4];
	
	public int GetDefence (DefenceType defType)
	{
		return defValue [(int)defType];
	}

	public void SetDefence (DefenceType defType, int value)
	{
		defValue [(int)defType] = value;
	}

	[SerializeField]
	private int
		speed = 6;

	public int Speed {
		get {
			return speed;
		}
		set {
			speed = value;
		}
	}

	private PowerTemplate[] powers;

	public PowerTemplate[] Powers {
		get {
			return powers;
		}
		set {
			powers = value;
		}
	}
}
