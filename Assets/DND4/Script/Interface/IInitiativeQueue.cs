using UnityEngine;
using System.Collections;

public interface IInitiativeQueue
{
	void AddNewUnit (GameUnit unit);
	void SortInitiative ();
	void UnitStartTurn ();
	void UnitEndTurn ();
}
