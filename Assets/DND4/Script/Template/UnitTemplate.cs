using UnityEngine;
using System.Collections;

public class UnitTemplate
{
	private int id;

	public int Id {
		get {
			return id;
		}
		set {
			id = value;
		}
	}

	private string name = string.Empty;

	public string Name {
		get {
			return name;
		}
		set {
			name = value;
		}
	}

	private int lv;

	public int Lv {
		get {
			return lv;
		}
		set {
			lv = value;
		}
	}

	private int hp;

	public int Hp {
		get {
			return hp;
		}
		set {
			hp = value;
		}
	}

	private int initiative;

	public int Initiative {
		get {
			return initiative;
		}
		set {
			initiative = value;
		}
	}

	private int speed;

	public int Speed {
		get {
			return speed;
		}
		set {
			speed = value;
		}
	}

	private int ac;
	
	public int Ac {
		get {
			return ac;
		}
		set {
			ac = value;
		}
	}

	private int fortitude;

	public int Fortitude {
		get {
			return fortitude;
		}
		set {
			fortitude = value;
		}
	}

	private int reflex;

	public int Reflex {
		get {
			return reflex;
		}
		set {
			reflex = value;
		}
	}

	private int will;

	public int Will {
		get {
			return will;
		}
		set {
			will = value;
		}
	}

	private string spriteName;

	public string SpriteName {
		get {
			return spriteName;
		}
		set {
			spriteName = value;
		}
	}
}
