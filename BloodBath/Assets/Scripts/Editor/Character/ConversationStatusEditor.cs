using System;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(ConversationStatus))]
public class ConversationStatusEditor : Editor {

	private ConversationStatus conversationStatus;

	public SerializedProperty conversationStatusesProperty;

	private SerializedProperty propertyUid;
	private SerializedProperty propertyQuestStatus;
	private SerializedProperty propertyContent;

	private void OnEnable()
	{
		conversationStatus = (ConversationStatus)target;

		if (target == null) {
			DestroyImmediate (this);
			return;
		}

		propertyUid = serializedObject.FindProperty ("uid");
		propertyQuestStatus = serializedObject.FindProperty ("questStatus");
		propertyContent = serializedObject.FindProperty ("content");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();
		EditorGUILayout.BeginHorizontal ();

		EditorGUILayout.PropertyField (propertyUid);
		EditorGUILayout.PropertyField (propertyQuestStatus);
		EditorGUILayout.PropertyField (propertyContent);

		if (GUILayout.Button("-", GUILayout.Width(30f))) {
			conversationStatusesProperty.RemoveFromObjectArray (conversationStatus);
		}

		serializedObject.ApplyModifiedProperties ();
	}


	public static ConversationStatus CreateConversationStatus(string content)
	{
		ConversationStatus status = CreateInstance<ConversationStatus> ();
		status.uid = Animator.StringToHash(content);
		status.content = content;

		return status;
	}
}
