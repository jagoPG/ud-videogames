using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollection : MonoBehaviour {

	public Quest[] quests;

	public Quest GetQuestOfUid(int uid)
	{
		for (int i = 0; i < quests.Length; i++) {
			if (quests[i].uid == uid) {
				return quests [i];
			}
		}

		return null;
	}
}
