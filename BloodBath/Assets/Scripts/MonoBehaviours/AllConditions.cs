using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllConditions : ScriptableObject {

	public Condition[] allConditions;
	private static AllConditions instance;

	private void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (instance);
			allConditions = FindObjectsOfType<Condition> ();
		} else {
			Destroy (this);
		}
	}

	public static AllConditions GetInstance()
	{
		return instance;
	}

	public void Reset()
	{
		for (int i = 0; i < allConditions.Length; i++) {
			allConditions [i].isSatisfied = false;
		}
	}
}
