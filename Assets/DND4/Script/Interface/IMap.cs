using UnityEngine;
using System.Collections;

public interface IMap
{
	void LookAtPos (VectorInt2 pos, EventDelegate.Callback callback);
	void AddGameUnit (GameUnit newUnit);
	void ShowArea (int x, int y, int size);
	void HideArea ();
}
