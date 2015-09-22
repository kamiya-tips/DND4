using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameWorld : MonoBehaviour
{
	//panel
	public GameObject startPanel;
	public GameObject deckPanel;
	public GameObject mainPanel;

	public Map gameMap;
	public InitiativeQueue initiativeQueue;
	public CenterMessage message;
	public TokenCard mainTokenCard;
	public TokenCard aimTokenCard;
	public ActionMenu actionMenu;

	private GameEncounter encounter = new GameEncounter ();

	public GameEncounter Encounter {
		get {
			return encounter;
		}
	}

	private EncounterTemplateManager encounterTemplateManager = new EncounterTemplateManager ();
	private UnitTemplateManager unitTemplateManager = new UnitTemplateManager ();

	public UnitTemplateManager UnitTemplateManager {
		get {
			return unitTemplateManager;
		}
	}

	private static GameWorld instance;

	public static GameWorld Instance {
		get {
			return instance;
		}
	}

	public void Start ()
	{
		if (GameWorld.instance == null) {
			GameWorld.instance = this;
		}
	}

	public void InitEncounter ()
	{
		//init
		unitTemplateManager.Init ();
		encounterTemplateManager.Init ();
		//show page
		startPanel.SetActive (false);
		deckPanel.SetActive (true);
		mainPanel.SetActive (true);
	}

	public void MapShowFinish ()
	{
		//load encounter
		EncounterTemplate encounterTemplate = encounterTemplateManager.GetTemplateById (1);
		encounter.Init (encounterTemplate);
	}
}
