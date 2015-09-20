using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EncounterTemplateManager
{
	private Dictionary<int,EncounterTemplate> templateDic = new Dictionary<int, EncounterTemplate> ();

	public void Init ()
	{
		EncounterTemplate template = new EncounterTemplate ();
		template.Id = 1;
		templateDic [template.Id] = template;

		EncounterUnitData data = new EncounterUnitData ();
		data.TemplateId = 4;
		data.Pos = new VectorInt2 (0, 5);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 5;
		data.Pos = new VectorInt2 (0, 6);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 6;
		data.Pos = new VectorInt2 (0, 7);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 7;
		data.Pos = new VectorInt2 (1, 5);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 8;
		data.Pos = new VectorInt2 (1, 7);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 3;
		data.Pos = new VectorInt2 (11, 8);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 3;
		data.Pos = new VectorInt2 (11, 9);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 2;
		data.Pos = new VectorInt2 (14, 10);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 2;
		data.Pos = new VectorInt2 (11, 16);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 2;
		data.Pos = new VectorInt2 (12, 17);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 2;
		data.Pos = new VectorInt2 (13, 17);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 2;
		data.Pos = new VectorInt2 (8, 17);
		template.UnitList.Add (data);

		data = new EncounterUnitData ();
		data.TemplateId = 1;
		data.Pos = new VectorInt2 (9, 16);
		template.UnitList.Add (data);

	}

	public EncounterTemplate GetTemplateById (int id)
	{
		return templateDic [id];
	}
}
