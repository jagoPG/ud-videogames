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
		for (int i = 0; i < requiredConditions.Length; i++) {
			if (!requiredConditions [i].isSatisfied) {
				Debug.Log ("False condition");

				return false;
			}
		}
		if (reactions != null) {
			reactions.React ();
		}

		return true;
	}
}
