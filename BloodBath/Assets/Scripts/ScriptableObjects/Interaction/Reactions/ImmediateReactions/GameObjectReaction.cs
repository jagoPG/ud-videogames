using UnityEngine;

[CreateAssetMenu]
public class GameObjectReaction : Reaction
{
	public GameObject gameObject;
	public bool actionState;

	protected override void ImmediateReaction ()
	{
		gameObject.SetActive (actionState);
	}
}
