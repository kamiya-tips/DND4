﻿using System.Collections.Generic;
using UnityEngine;

public class GameEncounter
{
	private List<GameUnit> unitList;
	private int round;
	private int nowUnitIndex;
	private EncounterTemplate encounterTemplate;

	public void Init (EncounterTemplate encounterTemplate)
	{
		this.encounterTemplate = encounterTemplate;
		//init unit
		unitList = new List<GameUnit> ();
		for (int i = 0; i < this.encounterTemplate.UnitList.Count; i++) {
			EncounterUnitData data = this.encounterTemplate.UnitList [i];
			//map token
			GameUnit unit = new GameUnit ();
			unit.Template = GameWorld.Instance.UnitTemplateManager.GetTemplateById (data.TemplateId);
			GameWorld.Instance.gameMap.AddGameUnit (unit);
			unit.X = data.Pos.X;
			unit.Y = data.Pos.Y;
			unit.UnitSide = data.UnitSide;
			unitList.Add (unit);
		}
		GameWorld.Instance.message.ShowMessage ("战斗开始", delegate () {
			GameWorld.Instance.message.ShowMessage ("投先攻", RollInitiative);
		});
	}

	private void RollInitiative ()
	{
		if (nowUnitIndex < unitList.Count) {
			GameUnit unit = unitList [nowUnitIndex];
			unit.Init (nowUnitIndex);
			unit.GameEncounter = this;
			unit.RollInitiative ();
			GameWorld.Instance.mainTokenCard.UpdateToken (unit);
			nowUnitIndex++;
			GameWorld.Instance.gameMap.LookAtPos (new VectorInt2 (unit.X, unit.Y), delegate {
				unit.UnitObject.SetActive (true);
				GameWorld.Instance.initiativeQueue.AddNewUnit (unit);
				GameWorld.Instance.message.ShowMessage (string.Format ("[0000FF]{0}[-]投先攻:[00FF00]{1}[-]", unit.Name, unit.InitiativeMessage ()), delegate {
					GameWorld.Instance.message.ShowMessage (string.Format ("[0000FF]{0}[-]先攻:[00FF00]{1}[-]", unit.Name, unit.InitiativeResultMessage ()), RollInitiative);
				});
			});
		} else {
			this.unitList.Sort (new InitiativeComparer ());
			GameWorld.Instance.message.ShowMessage ("先攻调整", StartRound);
		}
	}

	public void StartRound ()
	{
		GameWorld.Instance.initiativeQueue.SortInitiative ();
		foreach (GameUnit unit in unitList) {
			unit.StartRound ();
		}
		nowUnitIndex = 0;
		round++;
		GameWorld.Instance.message.ShowMessage (string.Format ("第{0}回合", round), NextUnit);
	}

	public void NextUnit ()
	{
		GameWorld.Instance.initiativeQueue.UnitEndTurn ();
		GameWorld.Instance.actionMenu.Hide ();
		if (nowUnitIndex >= unitList.Count) {
			StartRound ();
		} else {
			GameUnit nowUnit = unitList [nowUnitIndex];
			GameWorld.Instance.initiativeQueue.UnitStartTurn ();
			GameWorld.Instance.gameMap.LookAtPos (new VectorInt2 (nowUnit.X, nowUnit.Y), delegate {
				GameWorld.Instance.message.ShowMessage (string.Format ("[0000FF]{0}[-]开始行动", nowUnit.Name), delegate {
					nowUnit.StartTurn ();
					nowUnit.ShowMainMeun ();
				});
				GameWorld.Instance.mainTokenCard.UpdateToken (nowUnit);
			});
			nowUnitIndex++;
		}
	}

	public bool IsEmpty (int x, int y)
	{
		for (int i = 0; i < unitList.Count; i++) {
			if (unitList [i].X == x && unitList [i].Y == y) {
				return false;
			}
		}
		return true;
	}

	private GameUnit attacker = null;
	private int range;
	public bool IsSelectedState {
		get {
			return attacker != null;
		}
	}

	public void UnitOnClick (GameUnit clickUnit)
	{
		if (attacker != null) {
			if (attacker.IsEnemy (clickUnit) == true) {
				if (Mathf.Abs (clickUnit.X - attacker.X) <= range && Mathf.Abs (clickUnit.Y - attacker.Y) <= range) {
					attacker.DoAttackAction (clickUnit);
				}
			}
		}
	}

	public void ShowAttackTarget (GameUnit attacker, int range)
	{
		this.attacker = attacker;
		this.range = range;
		for (int i = 0; i < unitList.Count; i++) {
			GameUnit temp = unitList [i];
			if (attacker.IsEnemy (temp) == true) {
				if (Mathf.Abs (temp.X - attacker.X) <= range && Mathf.Abs (temp.Y - attacker.Y) <= range) {
					temp.ShowAttactedState ();
				}
			}
		}
	}

	public void HideAttackTarget ()
	{
		this.attacker = null;
		for (int i = 0; i < unitList.Count; i++) {
			unitList [i].HideAttackedState ();
		}
	}
}
