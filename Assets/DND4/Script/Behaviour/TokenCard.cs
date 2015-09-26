using UnityEngine;
using System.Collections;

public class TokenCard : MonoBehaviour
{
	public UISprite sprite;
	public UILabel unitName;
	public UILabel lv;
	public UILabel speed;
	public UILabel hp;
	public UILabel ac;
	public UILabel fortitude;
	public UILabel reflex;
	public UILabel will;
	private GameUnit showUnit;

	public void UpdateToken (GameUnit unit)
	{
		this.showUnit = unit;
		sprite.spriteName = unit.UnitObject.GetComponent<UISprite> ().spriteName;
		UIButton uiButton = sprite.gameObject.GetComponent<UIButton> ();
		if (uiButton != null) {
			uiButton.normalSprite = sprite.spriteName;
		}
		unitName.text = unit.Name;
		lv.text = unit.Template.Lv.ToString ();
		speed.text = unit.Template.Speed.ToString ();
		hp.text = unit.Hp.ToString () + "/" + unit.Template.Hp.ToString ();
		ac.text = unit.Template.Ac.ToString ();
		fortitude.text = unit.Template.Fortitude.ToString ();
		reflex.text = unit.Template.Reflex.ToString ();
		will.text = unit.Template.Will.ToString ();
	}

	public void OnClick ()
	{
		if (showUnit != null) {
			showUnit.OnClickAndShowMainMeun ();
		}
	}
}
