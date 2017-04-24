using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(ConversationStatusCollection))]
public class ConversationStatusCollectionEditor : EditorWithSubEditors<ConversationStatusEditor, ConversationStatus> {

	public SerializedProperty collectionsProperty;

	private ConversationStatusCollection statusesCollection;
	private SerializedProperty conversationStatusesProperty;


	private void OnEnable()
	{
		statusesCollection = (ConversationStatusCollection) target;

		if (target == null) {
			DestroyImmediate (this);
			return;
		}
	}

	public override void OnInspectorGUI ()
	{
		// Pull the information from the target into the serializedObject.
		serializedObject.Update ();

		// Check if the Editors for the Conditions need creating and optionally create them.
		CheckAndCreateSubEditors(statusesCollection.statuses);

		EditorGUILayout.BeginVertical(GUI.skin.box);
		EditorGUI.indentLevel++;

		EditorGUILayout.BeginHorizontal();

		// Display a button showing 'Remove Collection' which removes the target from the Interactable when clicked.
		if (GUILayout.Button("Remove Collection", GUILayout.Width(30f)))
		{
			collectionsProperty.RemoveFromObjectArray (statusesCollection);
		}

		EditorGUILayout.EndHorizontal();

	
		ExpandedGUI ();
		

		EditorGUI.indentLevel--;
		EditorGUILayout.EndVertical();

		// Push all changes made on the serializedObject back to the target.
		serializedObject.ApplyModifiedProperties();
	}

	private void ExpandedGUI ()
	{
		EditorGUILayout.Space();

		// Display the Labels for the Conditions evenly split over the width of the inspector.
		float space = EditorGUIUtility.currentViewWidth / 3f;

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Condition", GUILayout.Width(space));
		EditorGUILayout.LabelField("Satisfied?", GUILayout.Width(space));
		EditorGUILayout.LabelField("Add/Remove", GUILayout.Width(space));
		EditorGUILayout.EndHorizontal();

		// Display each of the Conditions.
		EditorGUILayout.BeginVertical(GUI.skin.box);
		for (int i = 0; i < subEditors.Length; i++)
		{
			subEditors[i].OnInspectorGUI();
		}
		EditorGUILayout.EndHorizontal();

		// Display a right aligned button which when clicked adds a Condition to the array.
		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace ();
		if (GUILayout.Button("+", GUILayout.Width(30f)))
		{
			ConversationStatus newStatus = ConversationStatusEditor.CreateConversationStatus("default");
			conversationStatusesProperty.AddToObjectArray(newStatus);
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
	}
}
