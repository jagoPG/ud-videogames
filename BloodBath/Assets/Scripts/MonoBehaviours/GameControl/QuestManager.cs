using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	private static QuestManager instance;

	public QuestCollection quests;
	public int uidOfActiveQuest;

	void Awake()
	{
		if (QuestManager.instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
}
