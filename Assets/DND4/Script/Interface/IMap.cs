using UnityEngine;
using System.Collections;

public interface IMap
{
	void LookAtPos (VectorInt2 pos, EventDelegate.Callback callback);
	void AddGameUnit (GameUnit newUnit);
	void ShowMoveArea (GameUnit moveUnit);
	void ShowRunArea (GameUnit moveUnit);
	void ShowShiftArea (GameUnit moveUnit);
}
