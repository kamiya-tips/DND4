using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitTemplateManager
{
	private Dictionary<int,UnitTemplate> templateDic = new Dictionary<int, UnitTemplate> ();

	public void Init ()
	{
		UnitTemplate template = new UnitTemplate ();
		template.Id = 1;
		template.Name = "狗头人投石者";
		template.Lv = 1;
		template.Ac = 13;
		template.Fortitude = 12;
		template.Reflex = 13;
		template.Will = 12;
		template.Hp = 24;
		template.Initiative = 3;
		template.Speed = 6;
		template.SpriteName = "S";
		templateDic [template.Id] = template;

		template = new UnitTemplate ();
		template.Id = 2;
		template.Name = "狗头人喽啰";
		template.Lv = 1;
		template.Ac = 15;
		template.Fortitude = 11;
		template.Reflex = 13;
		template.Will = 11;
		template.Hp = 1;
		template.Initiative = 3;
		template.Speed = 6;
		template.SpriteName = "M";
		templateDic [template.Id] = template;

		template = new UnitTemplate ();
		template.Id = 3;
		template.Name = "狗头人龙盾卫士";
		template.Lv = 2;
		template.Ac = 18;
		template.Fortitude = 14;
		template.Reflex = 13;
		template.Will = 13;
		template.Hp = 36;
		template.Initiative = 4;
		template.Speed = 6;
		template.SpriteName = "D";
		templateDic [template.Id] = template;
	}

	public UnitTemplate GetTemplateById (int id)
	{
		return templateDic [id];
	}
}
