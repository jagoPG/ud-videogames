using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
	public int uid;
	public int questUid;
	public ConversationStatus[] conversations;

	public ConversationStatus GetPhrases(Quest.QuestStatus status)
	{
		Debug.Log ("Quest Uid is " + questUid + " and status is " + status);

		if (conversations != null) {
			for (int i = 0; i < conversations.Length; i++) {
				if (conversations[i].questStatus == status) {
					return conversations[i];
				}
			}
		}

		return null;
	}
}