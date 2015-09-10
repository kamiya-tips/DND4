using UnityEngine;
using System.Collections;

public class TokenCard : MonoBehaviour,ITokenCard
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
	#region ITokenCard implementation
	public void UpdateToken (GameUnit unit)
	{
		sprite.spriteName = unit.UnitObject.GetComponent<UISprite> ().spriteName;
		unitName.text = unit.Name;
		lv.text = unit.Template.Lv.ToString ();
		speed.text = unit.Template.Speed.ToString ();
		hp.text = unit.Hp.ToString () + "/" + unit.Template.Hp.ToString ();
		ac.text = unit.Template.Ac.ToString ();
		fortitude.text = unit.Template.Fortitude.ToString ();
		reflex.text = unit.Template.Reflex.ToString ();
		will.text = unit.Template.Will.ToString ();
	}
	#endregion
	
}
