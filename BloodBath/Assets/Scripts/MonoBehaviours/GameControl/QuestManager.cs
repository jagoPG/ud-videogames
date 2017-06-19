using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	private static QuestManager instance;

	public QuestCollection quests;
	public List<Quest> finishedQuests;
	public int uidOfActiveQuest;

	public static QuestManager GetInstance()
	{
		return instance;
	}

	protected void Awake()
	{
		if (QuestManager.instance == null) {
			print ("Quest manager initialised");

			DontDestroyOnLoad (gameObject);
			instance = this;
			finishedQuests = new List<Quest> ();
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public Quest GetCurrentActiveQuest()
	{
		if (quests != null) {
			return quests.GetQuestOfUid (uidOfActiveQuest);
		}

		return null;
	}

	public void FinishQuest(int uid)
	{
		if (quests != null) {
			Quest quest = quests.GetQuestOfUid (uid);
			quest.finishQuest ();
			finishedQuests.Add (quest);
			ActivateNextQuest ();
		}
	}

	public ConversationStatus GetCurrentQuestCharacterConversation(Character character)
	{
		Conversation current = character.GetConversationOfQuestUid (uidOfActiveQuest);

		if (current != null) {
			return current.GetPhrases (Quest.QuestStatus.ACTIVE);
		}

		return null;
	}

	public ConversationStatus GetLatestCharacterConversation(Character character)
	{
		int length = finishedQuests.Capacity;
		bool isFound = false;
		Quest latestQuest = null;
		Conversation[] characterConversations = character.conversations;
		Conversation conversation = null;

		// Check other conversations
		for (int i = 0; i < length && !isFound; i++) {
			Quest current = finishedQuests [i];

			for (int j = 0; j < characterConversations.Length && !isFound; j++) {
				if (characterConversations[j].questUid == finishedQuests [i].uid) {
					latestQuest = finishedQuests[i];
					isFound = true;
					conversation = characterConversations [j];
				}	
			}
		}
		if (conversation != null) {
			return conversation.GetPhrases (Quest.QuestStatus.COMPLETED);
		}
			
		return null;
	}

	public void MakeQuestProgression(int uid)
	{
		this.uidOfActiveQuest = uid;
	}

	private void ActivateNextQuest ()
	{
		this.uidOfActiveQuest += 1;
	}
}
