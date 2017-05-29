using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllConditions : ScriptableObject {

	public Condition[] allConditions;
	public static AllConditions INSTANCE {
		get {
			return INSTANCE;
		}

		set {
			INSTANCE = value;
		}
	}

	private void Awake()
	{
		if (INSTANCE == null) {
			INSTANCE = this;
			DontDestroyOnLoad (INSTANCE);
			allConditions = FindObjectsOfType<Condition> ();
		} else {
			Destroy (this);
		}
	}


	public void Reset()
	{
		for (int i = 0; i < allConditions.Length; i++) {
			allConditions [i].isSatisfied = false;
		}
	}
}
