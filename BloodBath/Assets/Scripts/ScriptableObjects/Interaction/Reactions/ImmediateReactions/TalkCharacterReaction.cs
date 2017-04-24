using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalkCharacterReaction : Reaction {
	public Character character;
	private string phrase;

	protected override void SpecificInit()
	{
		Quest quest = QuestManager.GetInstance ().GetCurrentActiveQuest ();

		if (quest != null && character != null) {
			Conversation conversation = character.GetConversationOfQuestUid (quest.uid);
			if (conversation) {
				phrase = conversation.GetPhrases (Quest.QuestStatus.ACTIVE);
			} else {
				phrase = QuestManager.GetInstance ().GetLatestCharacterConversation (character);
			}
		}
	}

	protected override void ImmediateReaction()
	{
		if (character != null && phrase != null) {
			TextManager.getInstance().SetText (phrase, 3);
		}
	}
}
