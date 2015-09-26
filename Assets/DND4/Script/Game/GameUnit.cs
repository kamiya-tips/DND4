﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameUnit
{
	private bool isActive = false;

	public bool IsActive {
		get {
			return isActive;
		}
	}

	private GameObject unitObject;

	public GameObject UnitObject {
		get {
			return unitObject;
		}
		set {
			unitObject = value;
			unitObject.transform.localPosition = Vector3.zero;
			unitObject.transform.localScale = Vector3.one;
			UISprite sprite = unitObject.GetComponent<UISprite> ();
			sprite.spriteName = template.SpriteName;
			EventDelegate.Add (unitObject.GetComponent<UIButton> ().onClick, OnClickAndShowMainMeun);
		}
	}

	private GameObject initObject;

	public GameObject InitObject {
		get {
			return initObject;
		}
		set {
			initObject = value;
		}
	}

	private float tokenSize = 100.0f;

	private int x;

	public int X {
		get {
			return x;
		}
		set {
			x = value;
			unitObject.transform.localPosition = new Vector3 (x * tokenSize, y * tokenSize);
		}
	}

	private int y;

	public int Y {
		get {
			return y;
		}
		set {
			y = value;
			unitObject.transform.localPosition = new Vector3 (x * tokenSize, y * tokenSize);
		}
	}

	private GameEncounter gameEncounter;

	public GameEncounter GameEncounter {
		set {
			gameEncounter = value;
		}
	}

	private UnitTemplate template;

	public UnitTemplate Template {
		get {
			return template;
		}
		set {
			template = value;
		}
	}

	private int initiative;

	public int Initiative {
		get {
			return initiative;
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
	
	public int Bloodied {
		get {
			return template.Hp / 2;
		}
	}
	
	public int Surge {
		get {
			return template.Hp / 4;
		}
	}

	public bool IsBloodied {
		get {
			return hp <= Bloodied;
		}
	}

	public void TakeDamage (int damage)
	{
		hp -= damage;
	}
	private int index;

	public int Index {
		get {
			return index;
		}
	}

	public void Init (int index)
	{
		Hp = template.Hp;
		this.index = index;
	}

	public string Name {
		get{ return template.Name;}
	}

	public void RollInitiative ()
	{
		initiative = Dice.Roll (DiceType.D20, template.Initiative);
	}

	public void StartRound ()
	{

	}

	public void StartTurn ()
	{
		isActive = true;
	}

	public void EndTurn ()
	{
		isActive = false;
		gameEncounter.NextUnit ();
	}

	private int allSpeed = 0;
	private int leftSpeed = 0;

	private void ShowAreaWithAllSpeed (int allSpeed)
	{
		this.allSpeed = allSpeed;
		leftSpeed = this.allSpeed;
		GameWorld.Instance.gameMap.MoveGameUnit = this;
		ShowMenuAndArea ();
	}

	public void MoveTileOnClick (GameObject mapTile)
	{
		MoveTile tile = mapTile.GetComponent<MoveTile> ();
		Debug.Log (tile.x);
		Debug.Log (tile.y);
		Debug.Log (tile.deltaX);
		Debug.Log (tile.deltaY);
	}

	private void ShowMenuAndArea ()
	{
		//show menu
		List<ActionMenuItem> actionList = new List<ActionMenuItem> ();
		if (leftSpeed < allSpeed) {
			actionList.Add (BuildActionMenuItem ("上一步", BackStep, true));
			actionList.Add (BuildActionMenuItem ("开始移动", DoMoveAction, true));
		}
		actionList.Add (BuildActionMenuItem ("返回", delegate() {
			ShowMainMeun ();
			GameWorld.Instance.gameMap.HideArea ();
		}, true));
		GameWorld.Instance.actionMenu.Show (0, 0, actionList);
		//show area
		GameWorld.Instance.gameMap.ShowMoveArea (x, y, leftSpeed);
	}

	private void DoMoveAction ()
	{

	}

	private void BackStep ()
	{

	}

	public void OnClickAndShowMainMeun ()
	{
		GameWorld.Instance.actionMenu.Hide ();
		if (isActive == true) {
			GameWorld.Instance.gameMap.LookAtPos (new VectorInt2 (x, y), ShowMainMeun);
		} else {
			GameWorld.Instance.gameMap.LookAtPos (new VectorInt2 (x, y), null);
		}
		GameWorld.Instance.aimTokenCard.UpdateToken (this);
	}

	public void ShowMainMeun ()
	{
		List<ActionMenuItem> actionList = new List<ActionMenuItem> ();
		actionList.Add (BuildActionMenuItem ("移动动作", ShowMoveMenu, true));
		actionList.Add (BuildActionMenuItem ("回合结束", EndTurn, true));
		GameWorld.Instance.actionMenu.Show (actionList);
	}

	private void ShowMoveMenu ()
	{
		List<ActionMenuItem> actionList = new List<ActionMenuItem> ();
		actionList.Add (BuildActionMenuItem ("快步", delegate {
			ShowAreaWithAllSpeed (1);
		}, true));
		actionList.Add (BuildActionMenuItem ("移动", delegate {
			ShowAreaWithAllSpeed (template.Speed);
		}, true));
		actionList.Add (BuildActionMenuItem ("奔跑", delegate {
			ShowAreaWithAllSpeed (template.Speed + 2);
		}, true));
		actionList.Add (BuildActionMenuItem ("返回", ShowMainMeun, true));
		GameWorld.Instance.actionMenu.Show (actionList);
	}

	private ActionMenuItem BuildActionMenuItem (string name, EventDelegate.Callback onClick, bool enable)
	{
		ActionMenuItem item = new ActionMenuItem ();
		item.Name = name;
		item.OnClick = onClick;
		item.Enable = enable;
		return item;
	}
}
