using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject {

	public enum QuestStatus { NOT_AVAILABLE, COMPLETED, AVAILABLE, ACTIVE };

	public int uid;
	public string title;
	public string description;

	public QuestStatus status;
	public Character[] characters;


	public void finishQuest()
	{
		this.status = QuestStatus.COMPLETED;
	}

	public void makeAvailableQuest()
	{
		this.status = QuestStatus.AVAILABLE;
	}

	public void startQuest()
	{
		this.status = QuestStatus.ACTIVE;
	}
}
