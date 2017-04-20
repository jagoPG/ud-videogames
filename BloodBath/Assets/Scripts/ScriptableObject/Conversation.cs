using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
	public string uid { set; get; }
	public string questUid { set; get; }
	public ConversationStatus conversations { set; get; }

	public Conversation(string uid, string questUid)
		{
		this.uid = uid;
		this.questUid = questUid;
	}
}


