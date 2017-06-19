using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CompleteQuestReaction : Reaction {

	public int questUid;

	protected override void ImmediateReaction ()
	{
		Debug.Log ("Complete quest " + questUid);

		QuestManager.GetInstance ().FinishQuest (questUid);
	}
}
