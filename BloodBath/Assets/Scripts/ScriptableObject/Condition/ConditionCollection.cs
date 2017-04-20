using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCollection : ScriptableObject
{
	public string collection;
	public Condition[] requiredConditions = new Condition[0];

	public bool Check()
	{
		for (int i = 0; i < requiredConditions.Length; i++) {
			if (!requiredConditions [i]) {
				return false;
			}
		}

		return true;
	}
}
