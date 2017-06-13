using UnityEngine;

[CreateAssetMenu]
public class GameObjectReaction : Reaction
{
	public string name;
	public bool actionState;

	protected override void ImmediateReaction ()
	{
		Debug.Log ("Game Object Reaction. Set Active?: " + actionState);

		GameObject obj = GameObject.Find (name);
		obj.SetActive (actionState);
	}
}
