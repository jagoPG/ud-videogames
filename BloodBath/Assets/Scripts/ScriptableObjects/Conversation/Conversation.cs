using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
	public int uid;
	public int questUid;
	public ConversationStatus[] conversations;

	public string GetPhrases(Quest.QuestStatus status)
	{
		if (conversations != null) {
			for (int i = 0; i < conversations.Length; i++) {
				if (conversations[i].questStatus == status) {
					return conversations[i].content;
				}
			}
		}

		return null;
	}
}