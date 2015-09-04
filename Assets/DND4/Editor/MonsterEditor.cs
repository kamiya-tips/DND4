using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MonsterTemplate))]
public class MonsterEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();

		MonsterTemplate monster = (MonsterTemplate)target;

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("Lv");
		monster.Lv = EditorGUILayout.IntField (monster.Lv);
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("MaxHP");
		monster.MaxHp = EditorGUILayout.IntField (monster.MaxHp);
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("Initiative");
		monster.Initiative = EditorGUILayout.IntField (monster.Initiative);
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("Speed");
		monster.Speed = EditorGUILayout.IntField (monster.Speed);
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("AC");
		monster.SetDefence (DefenceType.AC, EditorGUILayout.IntField (monster.GetDefence (DefenceType.AC)));
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("Fortitude");
		monster.SetDefence (DefenceType.FORTITUDE, EditorGUILayout.IntField (monster.GetDefence (DefenceType.FORTITUDE)));
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("Reflex");
		monster.SetDefence (DefenceType.REFLEX, EditorGUILayout.IntField (monster.GetDefence (DefenceType.REFLEX)));
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PrefixLabel ("Will");
		monster.SetDefence (DefenceType.WILL, EditorGUILayout.IntField (monster.GetDefence (DefenceType.WILL)));
		EditorGUILayout.EndHorizontal ();

		serializedObject.ApplyModifiedProperties ();
	}
}
