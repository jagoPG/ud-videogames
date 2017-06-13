using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	private static ObjectManager instance;

	public static ObjectManager GetInstance()
	{
		return instance;
	}

	private void Awake ()
	{
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void HideDynamicObstacle(int uid)
	{

	}
}
