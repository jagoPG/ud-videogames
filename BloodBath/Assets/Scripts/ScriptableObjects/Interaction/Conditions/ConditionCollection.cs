using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ConditionCollection : ScriptableObject
{
	public string description;
	public Condition[] requiredConditions = new Condition[0];
	public ReactionCollection reactions;

	public bool Check()
	{
		Debug.Log ("Check conditions: " + description);
		for (int i = 0; i < requiredConditions.Length; i++) {
			if (!requiredConditions [i].isSatisfied) {
				Debug.Log ("False condition");

				return false;
			}
		}
		Debug.Log ("True condition");

		if (reactions != null) {
			reactions.React ();
		}

		return true;
	}
}
