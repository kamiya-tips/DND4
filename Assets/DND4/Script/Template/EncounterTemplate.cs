using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EncounterTemplate
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

	private List<EncounterUnitData> unitList = new List<EncounterUnitData> ();

	public List<EncounterUnitData> UnitList {
		get {
			return unitList;
		}
		set {
			unitList = value;
		}
	}
}
