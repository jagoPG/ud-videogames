using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ConversationStatus : ScriptableObject
{
	public int uid;
	public Quest.QuestStatus questStatus;
	public string content;
	public float delay;
}
