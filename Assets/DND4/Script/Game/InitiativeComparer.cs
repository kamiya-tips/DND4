using UnityEngine;
using System.Collections.Generic;

public class InitiativeComparer : IComparer<GameUnit>
{
	public int Compare (GameUnit x, GameUnit y)
	{
		if (x.Initiative > y.Initiative) {
			return 1;
		} else if (x.Initiative == y.Initiative) {
			return 0;
		} else {
			return -1;
		}
	}
}
