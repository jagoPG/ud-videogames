using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalkCharacterReaction : Reaction {

	public Character character;
	private ConversationStatus phrase;

	protected override void SpecificInit()
	{
		
	}

	protected override void ImmediateReaction()
	{
		Quest quest = QuestManager.GetInstance ().GetCurrentActiveQuest ();

		if (quest != null && character != null) {
			Debug.Log ("[TalkCharacterReaction] Get conversation of uid " + quest.uid);
			Conversation conversation = character.GetConversationOfQuestUid (quest.uid);

			if (conversation != null) {
				phrase = conversation.GetPhrases (Quest.QuestStatus.ACTIVE);
			} else {
				phrase = QuestManager.GetInstance ().GetLatestCharacterConversation (character);
			}
		}

		if (character != null && phrase != null) {
			TextManager.GetInstance().SetText (phrase.content, phrase.delay, character.image);
		}
	}
}
