using UnityEngine;
using System.Collections;

public class Dice
{
	public static int Roll (int max)
	{
		return Random.Range (0, max) + 1;
	}

	public static int Roll (int number, DiceType type, int modify)
	{
		int result = modify;
		for (int i = 0; i < number; i++) {
			result += Dice.Roll ((int)type);
		}
		return result;
	}

	public static int Roll (DiceType type)
	{
		return Dice.Roll (1, type, 0);
	}

	public static int Roll (int number, DiceType type)
	{
		return Dice.Roll (number, type, 0);
	}
	
	public static int Roll (DiceType type, int modify)
	{
		return Dice.Roll (1, type, modify);
	}
}
