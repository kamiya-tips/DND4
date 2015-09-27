using UnityEngine;
using System.Collections.Generic;

public class InitiativeComparer : IComparer<GameUnit>
{
	public int Compare (GameUnit x, GameUnit y)
	{
		int init = x.Initiative.CompareTo (y.Initiative);
		if (init == 0) {
			int initT = x.Template.Initiative.CompareTo (y.Template.Initiative);
			if (initT == 0) {
				return x.Index.CompareTo (y.Index);
			} else {
				return -initT;
			}
		} else {
			return -init;
		}
	}
}
