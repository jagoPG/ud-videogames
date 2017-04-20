using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public int uid { set; get; }
	public string name { set; get; }
	public Conversation[] conversations { get; }
}
