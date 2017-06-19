using UnityEngine;

public class Interactable : MonoBehaviour
{
	public Transform interactionLocation;
	public ConditionCollection[] conditionCollections = new ConditionCollection[0];
	public ReactionCollection defaultReactionCollection;
	public ReactionCollection conditionNotAccomplished;

	public void Interact ()
	{
		for (int i = 0; i < conditionCollections.Length; i++)
		{
			if (!conditionCollections [i].Check ()) {
				Debug.Log ("Reaction not launched");
				if (conditionNotAccomplished != null) {
					conditionNotAccomplished.React ();
				}

				return;
			}
		}

		Debug.Log ("Reaction launched");
		defaultReactionCollection.React ();
	}
}