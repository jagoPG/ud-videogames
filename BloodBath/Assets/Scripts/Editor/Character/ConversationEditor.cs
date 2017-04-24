using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConversationCollectionEditor : Editor {

	private Conversation conversation;

	private SerializedProperty propertyUid;
	private SerializedProperty propertyQuestUid;
	private SerializedProperty propertyConversations;

	private void OnEnable()
	{
		conversation = (Conversation) target;

		if (target == null) {
			DestroyImmediate (this);
			return;
		}

		propertyUid = serializedObject.FindProperty("uid");
		propertyQuestUid = serializedObject.FindProperty ("questUid");
		propertyConversations = serializedObject.FindProperty ("conversations");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();

		EditorGUILayout.PropertyField (propertyUid);
		EditorGUILayout.PropertyField (propertyQuestUid);
		EditorGUILayout.PropertyField (propertyConversations);

		serializedObject.ApplyModifiedProperties ();
	}
}
