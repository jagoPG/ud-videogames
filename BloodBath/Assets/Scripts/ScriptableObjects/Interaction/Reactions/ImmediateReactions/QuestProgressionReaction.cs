using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestProgressionReaction : Reaction {

	public int currentQuestUid;
	public int nextQuestUid;
	public Condition[] conditions = new Condition[0];

	protected override void ImmediateReaction ()
	{
		Quest quest = QuestManager.GetInstance ().GetCurrentActiveQuest();
		if (quest.uid == currentQuestUid) {
			QuestManager.GetInstance ().MakeQuestProgression (nextQuestUid);

			foreach (Condition condition in conditions) {
				condition.isSatisfied = true;
			}
		}
	}
}
