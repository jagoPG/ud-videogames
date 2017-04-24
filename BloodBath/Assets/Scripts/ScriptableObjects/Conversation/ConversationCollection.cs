using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationCollection : ScriptableObject
{
	public string description;
	public Conversation[] conversations = new Conversation[0];
}
