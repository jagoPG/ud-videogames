using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject 
{
	public int uid;
	public string name;
	public string description;

	public GameObject gameObject;
}
