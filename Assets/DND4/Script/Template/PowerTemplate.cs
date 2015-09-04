using UnityEngine;
using System.Collections;

public class PowerTemplate
{
	private ActionType actionType = ActionType.STANDARD;

	public ActionType ActionType {
		get {
			return actionType;
		}
		set {
			actionType = value;
		}
	}

	private RechargeType rechargeType = RechargeType.ATWILL;

	public RechargeType RechargeType {
		get {
			return rechargeType;
		}
		set {
			rechargeType = value;
		}
	}

	private RangeType rangeType = RangeType.BASIC;

	public RangeType RangeType {
		get {
			return rangeType;
		}
		set {
			rangeType = value;
		}
	}

	private int bulletNumber = 20;

	public int BulletNumber {
		get {
			return bulletNumber;
		}
		set {
			bulletNumber = value;
		}
	}

	private int[] range = new int[2];

	public int[] Range {
		get {
			return range;
		}
		set {
			range = value;
		}
	}
	
	private int basicAttack;

	public int BasicAttack {
		get {
			return basicAttack;
		}
		set {
			basicAttack = value;
		}
	}

	private DefenceType defType = DefenceType.AC;

	public DefenceType DefType {
		get {
			return defType;
		}
		set {
			defType = value;
		}
	}

	private int diceNumber = 1;

	public int DiceNumber {
		get {
			return diceNumber;
		}
		set {
			diceNumber = value;
		}
	}

	private DiceType diceType = DiceType.D6;

	public DiceType DiceType {
		get {
			return diceType;
		}
		set {
			diceType = value;
		}
	}

	private int basicDamage;

	public int BasicDamage {
		get {
			return basicDamage;
		}
		set {
			basicDamage = value;
		}
	}
}
