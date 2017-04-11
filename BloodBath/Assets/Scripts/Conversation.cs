using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Conversation 
{
 	public class Conversation 
	{
		public string Uid { set; get; }
		public string QuestUid { set; get; }

		public Conversation(string Uid, string QuestUid)
		{
			this.Uid = Uid;
			this.QuestUid = QuestUid;
		}
	}

	public class ConversationStatus {
		public string Uid { set; get; }
		public int Status { set; get; }
		public int Progress { set; get; }
		public List<string> Messages { set; get; }

		public const int CONVERSATION_STATUS_NOT_AVAILABLE = 0;
		public const int CONVERSATION_STATUS_QUEST_COMPLETED = 1;
		public const int CONVERSATION_SATUS_AVAILABLE = 2;
		public const int CONVERSATION_STATUS_QUEST_ACTIVE = 3;

		public ConversationStatus(string Uid, int Status, int Progress, List<string> Messages)
		{
			this.Uid = Uid;
			this.Status = Status;
			this.Progress = Progress;
			this.Messages = Messages;
		}
	}
}