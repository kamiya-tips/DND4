using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameWorld : MonoBehaviour
{
	//panel
	public GameObject startPanel;
	public GameObject deckPanel;
	public GameObject mainPanel;
	//message
	public GameObject messageObject;
	//map
	public GameObject mapObject;
	public GameObject mapToken;
	//initiative queue
	public Transform initRoot;

	private Map gameMap = new Map ();
	private InitiativeQueue initiativeQueue = new InitiativeQueue ();
	private GameEncounter gameEncounter = new GameEncounter ();
	private EncounterTemplateManager encounterTemplateManager = new EncounterTemplateManager ();
	private UnitTemplateManager unitTemplateManager = new UnitTemplateManager ();
	private CenterMessage message = new CenterMessage ();

	public void InitEncounter ()
	{
		initiativeQueue.Init (initRoot);
		unitTemplateManager.Init ();
		encounterTemplateManager.Init ();
		gameMap.Init (mapObject.GetComponent<TweenPosition> (), mapObject.transform, mapToken);
		message.Init (messageObject.GetComponent<UILabel> (), messageObject.GetComponent<TweenPosition> ());
		//show page
		startPanel.SetActive (false);
		deckPanel.SetActive (true);
		mainPanel.SetActive (true);
	}

	public void MapShowFinish ()
	{
		//load encounter
		EncounterTemplate encounterTemplate = encounterTemplateManager.GetTemplateById (1);
		gameEncounter.Init (encounterTemplate, unitTemplateManager, message, initiativeQueue, gameMap);
	}
}
