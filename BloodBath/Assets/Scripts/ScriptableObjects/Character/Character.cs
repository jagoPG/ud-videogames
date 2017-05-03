using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Character : ScriptableObject
{
	public int uid;
	public string name;
	public Conversation[] conversations;
	public Sprite image;

	public Conversation GetConversationOfQuestUid(int uid)
	{
		if (conversations != null) {
			for (int i = 0; i < conversations.Length; i++) {
				if (conversations [i].questUid == uid) {
					return conversations [i];
				}
			}
		}

		return null;
	}
}
