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

		template = new UnitTemplate ();
		template.Id = 4;
		template.Name = "矮人战士";
		template.Lv = 1;
		template.Ac = 17;
		template.Fortitude = 15;
		template.Reflex = 11;
		template.Will = 12;
		template.Hp = 31;
		template.Initiative = 1;
		template.Speed = 5;
		template.SpriteName = "1";
		templateDic [template.Id] = template;

		template = new UnitTemplate ();
		template.Id = 5;
		template.Name = "半身人盗贼";
		template.Lv = 1;
		template.Ac = 16;
		template.Fortitude = 11;
		template.Reflex = 16;
		template.Will = 13;
		template.Hp = 25;
		template.Initiative = 4;
		template.Speed = 6;
		template.SpriteName = "2";
		templateDic [template.Id] = template;

		template = new UnitTemplate ();
		template.Id = 6;
		template.Name = "人类法师";
		template.Lv = 1;
		template.Ac = 14;
		template.Fortitude = 12;
		template.Reflex = 15;
		template.Will = 15;
		template.Hp = 23;
		template.Initiative = 6;
		template.Speed = 6;
		template.SpriteName = "3";
		templateDic [template.Id] = template;

		template = new UnitTemplate ();
		template.Id = 7;
		template.Name = "半精灵牧师";
		template.Lv = 1;
		template.Ac = 16;
		template.Fortitude = 12;
		template.Reflex = 10;
		template.Will = 15;
		template.Hp = 26;
		template.Initiative = 0;
		template.Speed = 6;
		template.SpriteName = "4";
		templateDic [template.Id] = template;

		template = new UnitTemplate ();
		template.Id = 8;
		template.Name = "龙裔圣武士";
		template.Lv = 1;
		template.Ac = 20;
		template.Fortitude = 14;
		template.Reflex = 12;
		template.Will = 13;
		template.Hp = 27;
		template.Initiative = 0;
		template.Speed = 6;
		template.SpriteName = "5";
		templateDic [template.Id] = template;
	}

	public UnitTemplate GetTemplateById (int id)
	{
		return templateDic [id];
	}
}
