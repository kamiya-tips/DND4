using UnityEngine;
using System.Collections.Generic;

public class InitiativeComparer : IComparer<GameUnit>
{
	public int Compare (GameUnit x, GameUnit y)
	{
		if (x.Initiative > y.Initiative) {
			return 1;
		} else if (x.Initiative == y.Initiative) {
			if (x.Template.Initiative > y.Template.Initiative) {
				return 1;
			} else if (x.Template.Initiative == y.Template.Initiative) {
				if (x.Index > y.Index) {
					return 1;
				} else if (x.Index > y.Index) {
					//never execute this
					return 0;
				} else {
					return -1;
				}
			} else {
				return -1;
			}
		} else {
			return -1;
		}
	}
}
