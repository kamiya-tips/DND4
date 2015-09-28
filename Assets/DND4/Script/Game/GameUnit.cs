using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameUnit
{
	private UnitSide unitSide;

	public UnitSide UnitSide {
		get {
			return unitSide;
		}
		set {
			unitSide = value;
		}
	}

	public bool IsEnemy (GameUnit targetUnit)
	{
		return UnitSide != targetUnit.UnitSide;
	}

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

	private int x;

	public int X {
		get {
			return x;
		}
		set {
			x = value;
			unitObject.transform.localPosition = new Vector3 (x * GameWorld.Instance.gameMap.tileSize, y * GameWorld.Instance.gameMap.tileSize);
		}
	}

	private int y;

	public int Y {
		get {
			return y;
		}
		set {
			y = value;
			unitObject.transform.localPosition = new Vector3 (x * GameWorld.Instance.gameMap.tileSize, y * GameWorld.Instance.gameMap.tileSize);
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
		movePath.Clear ();
		ShowMenuAndArea ();
	}

	private List<VectorInt2> movePath = new List<VectorInt2> ();

	public void MoveTileOnClick (GameObject mapTile)
	{
		MoveTile tile = mapTile.GetComponent<MoveTile> ();
		int speedCost = Mathf.Max (Mathf.Abs (tile.deltaX), Mathf.Abs (tile.deltaY));
		leftSpeed -= speedCost;
		// make path
		int speedX = 0;
		if (tile.deltaX != 0) {
			speedX = tile.deltaX / Mathf.Abs (tile.deltaX);
		}
		int speedY = 0;
		if (tile.deltaY != 0) {
			speedY = tile.deltaY / Mathf.Abs (tile.deltaY);
		}
		for (int i = 1; i <= speedCost; i++) {
			int posX = speedX * i;
			if (Mathf.Abs (posX) > Mathf.Abs (tile.deltaX)) {
				posX = tile.deltaX;
			}
			int posY = speedY * i;
			if (Mathf.Abs (posY) > Mathf.Abs (tile.deltaY)) {
				posY = tile.deltaY;
			}
			VectorInt2 newPos = new VectorInt2 (tile.x + posX, tile.y + posY);
			movePath.Add (newPos);
		}
		GameWorld.Instance.gameMap.ShowStep (movePath);
		GameWorld.Instance.gameMap.LookAtPos (movePath [movePath.Count - 1], delegate {
			ShowMenuAndArea ();
		});
	}

	private void ShowMenuAndArea ()
	{
		//show menu
		List<ActionMenuItem> actionList = new List<ActionMenuItem> ();
		if (leftSpeed < allSpeed) {
			actionList.Add (BuildActionMenuItem ("上一步", BackStep, true));
			actionList.Add (BuildActionMenuItem ("开始移动", delegate() {
				GameWorld.Instance.gameMap.HideArea ();
				GameWorld.Instance.gameMap.HideStep ();
				GameWorld.Instance.actionMenu.Hide ();
				DoMoveAction ();
			}, true));
		}
		actionList.Add (BuildActionMenuItem ("返回", delegate() {
			GameWorld.Instance.gameMap.LookAtPos (new VectorInt2 (this.x, this.y), ShowMoveMenu);
			GameWorld.Instance.gameMap.HideArea ();
			GameWorld.Instance.gameMap.HideStep ();
		}, true));
		GameWorld.Instance.actionMenu.Show (0, 0, actionList);
		//show area
		if (movePath.Count > 0) {
			GameWorld.Instance.gameMap.ShowMoveArea (movePath [movePath.Count - 1].X, movePath [movePath.Count - 1].Y, leftSpeed);
		} else {
			GameWorld.Instance.gameMap.ShowMoveArea (x, y, leftSpeed);
		}
	}

	private void DoMoveAction ()
	{
		GameWorld.Instance.gameMap.LookAtPos (movePath [0], delegate() {
			X = movePath [0].X;
			Y = movePath [0].Y;
			movePath.RemoveAt (0);
			if (movePath.Count > 0) {
				DoMoveAction ();
			} else {
				ShowMainMeun ();
			}
		});
	}

	private void BackStep ()
	{
		VectorInt2 prePos;
		do {
			leftSpeed++;
			movePath.RemoveAt (movePath.Count - 1);
			if (leftSpeed == allSpeed) {
				prePos = new VectorInt2 (x, y);
				break;
			} else {
				prePos = movePath [movePath.Count - 1];
			}
		} while (GameWorld.Instance.Encounter.IsEmpty (prePos.X, prePos.Y)==false);
		GameWorld.Instance.gameMap.ShowStep (movePath);
		GameWorld.Instance.gameMap.LookAtPos (prePos, ShowMenuAndArea);
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
