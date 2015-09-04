using System.Collections.Generic;

public class GameEncounter
{
	private List<GameUnit> unitList;
	private int round;
	private int nowUnitIndex;
	private IMessage message;
	private IInitiativeQueue initiativeQueue;
	private IMap map;
	private EncounterTemplate encounterTemplate;
	private UnitTemplateManager unitTemplateManager;

	public void Init (EncounterTemplate encounterTemplate, UnitTemplateManager unitTemplateManager, IMessage message, IInitiativeQueue initiativeQueue, IMap map)
	{
		this.encounterTemplate = encounterTemplate;
		this.unitTemplateManager = unitTemplateManager;
		this.message = message;
		this.initiativeQueue = initiativeQueue;
		this.map = map;
		//init unit
		unitList = new List<GameUnit> ();
		for (int i = 0; i < encounterTemplate.UnitList.Count; i++) {
			EncounterUnitData data = encounterTemplate.UnitList [i];
			//map token
			GameUnit unit = new GameUnit ();
			unit.Template = unitTemplateManager.GetTemplateById (data.TemplateId);
			this.map.AddGameUnit (unit);
			unit.X = data.Pos.X;
			unit.Y = data.Pos.Y;
			unitList.Add (unit);
		}
		this.message.ShowMessage ("战斗开始", delegate () {
			this.message.ShowMessage ("投先攻", RollInitiative);
		});
	}

	private void RollInitiative ()
	{
		if (nowUnitIndex < unitList.Count) {
			GameUnit unit = unitList [nowUnitIndex];
			unit.Init ();
			unit.RollInitiative ();
			initiativeQueue.AddNewUnit (unit);
			nowUnitIndex++;

			this.map.LookAtPos (new VectorInt2 (unit.X, unit.Y), delegate {
				this.message.ShowMessage (string.Format ("[0000FF]{0}[-]先攻:[00FF00]{1}[-]", unit.Name, unit.Initiative), RollInitiative);
			});
		} else {
			this.unitList.Sort (new InitiativeComparer ());
			this.message.ShowMessage ("先攻调整", StartRound);
		}
	}


	public void StartRound ()
	{
		foreach (GameUnit unit in unitList) {
			unit.StartRound ();
		}
		nowUnitIndex = 0;
		round++;
		this.message.ShowMessage (string.Format ("第{0}回合", round), null);
	}

	public void NextUnit ()
	{
		if (nowUnitIndex >= unitList.Count) {
			StartRound ();
		}
		unitList [nowUnitIndex].StartTurn ();
		nowUnitIndex++;
	}
}
