using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
	private bool[] showItemSlots = new bool[Inventory.maxSize];
	private SerializedProperty itemTitleProperty;
	private SerializedProperty itemProperty;

	private void OnEnable()
	{
		itemTitleProperty = serializedObject.FindProperty ("names");
		itemProperty = serializedObject.FindProperty ("items");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();
		for (int i = 0; i < Inventory.maxSize; i++) {
			ItemSlotGUI (i);
		}
		serializedObject.ApplyModifiedProperties ();
	}

	private void ItemSlotGUI (int index)
	{
		EditorGUILayout.BeginVertical (GUI.skin.box);
		EditorGUI.indentLevel++;

		showItemSlots [index] = EditorGUILayout.Foldout (showItemSlots [index], "Item slot " + index);
		if (showItemSlots [index]) {
			EditorGUILayout.PropertyField (itemTitleProperty.GetArrayElementAtIndex (index));
			EditorGUILayout.PropertyField (itemProperty.GetArrayElementAtIndex (index));
		}

		EditorGUI.indentLevel--;
		EditorGUILayout.EndVertical ();
	}
}
