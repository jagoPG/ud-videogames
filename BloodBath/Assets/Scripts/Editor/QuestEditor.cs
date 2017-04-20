using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestCollection))]
public class QuestEditor : Editor
{
	string[] QUEST_STATUS = { "Available", "Not available", "Active", "Finished" };

	SerializedProperty uid;
	SerializedProperty title;
	SerializedProperty description;
	SerializedProperty status;

	void OnEnable()
	{
		uid = this.serializedObject.FindProperty ("uid");
		title = this.serializedObject.FindProperty ("title");
		description = this.serializedObject.FindProperty ("description");
		status = this.serializedObject.FindProperty ("status");
	}

	void OnInspectorGUI()
	{
		this.serializedObject.Update ();
		EditorGUILayout.PropertyField (uid);
		EditorGUILayout.PropertyField (title);
		EditorGUILayout.PropertyField (description);
		EditorGUILayout.PropertyField (status);
		this.serializedObject.ApplyModifiedProperties ();
	}
}
