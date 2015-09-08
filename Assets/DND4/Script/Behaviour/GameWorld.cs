using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameWorld : MonoBehaviour,IMessage
{
	public GameObject startPanel;
	public GameObject deckPanel;
	public GameObject mainPanel;
	public UILabel messageLabel;
	public UITweener messageTweener;
	public GameObject mapObject;
	public GameObject mapToken;
	public Transform initRoot;
	private Map gameMap = new Map ();
	private InitiativeQueue initiativeQueue = new InitiativeQueue ();
	private GameEncounter gameEncounter = new GameEncounter ();
	private EncounterTemplateManager encounterTemplateManager = new EncounterTemplateManager ();
	private UnitTemplateManager unitTemplateManager = new UnitTemplateManager ();

	public void InitEncounter ()
	{
		initiativeQueue.Init (initRoot);
		startPanel.SetActive (false);
		deckPanel.SetActive (true);
		mainPanel.SetActive (true);
		unitTemplateManager.Init ();
		encounterTemplateManager.Init ();
		gameMap.Init (mapObject.GetComponent<TweenPosition> (), mapObject.transform, mapToken);
	}

	public void MapShowFinish ()
	{
		//load encounter
		EncounterTemplate encounterTemplate = encounterTemplateManager.GetTemplateById (1);
		gameEncounter.Init (encounterTemplate, unitTemplateManager, this, initiativeQueue, gameMap);
	}

	#region IMessage implementation
	public void ShowMessage (string msg, EventDelegate.Callback callback)
	{
		messageLabel.text = msg;
		messageTweener.ResetToBeginning ();
		EventDelegate.Add (messageTweener.onFinished, callback, true);
		messageTweener.PlayForward ();
	}
	#endregion
}
