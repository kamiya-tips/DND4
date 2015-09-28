using UnityEngine;
using System.Collections;

public class EncounterUnitData
{
	private int templateId;

	public int TemplateId {
		get {
			return templateId;
		}
		set {
			templateId = value;
		}
	}

	private VectorInt2 pos;

	public VectorInt2 Pos {
		get {
			return pos;
		}
		set {
			pos = value;
		}
	}

	private UnitSide unitSide;

	public UnitSide UnitSide {
		get {
			return unitSide;
		}
		set {
			unitSide = value;
		}
	}
}
