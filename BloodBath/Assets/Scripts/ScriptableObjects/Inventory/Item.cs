using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Item : ScriptableObject 
{
	public int uid;
	public string name;
	public string description;

	public Sprite sprite;
}
