using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public Camera camera;
	public Gradient gradient;

	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		GradientColorKey[] colorKey = new GradientColorKey[2];
		GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];

		// Populate the color keys at the relative time 0 and 1 (0 and 100%)
		colorKey[0].color = Color.red;
		colorKey[0].time = 0.0f;
		colorKey[1].color = Color.blue;
		colorKey[1].time = 1.0f;

		// Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
		alphaKey[0].alpha = 1.0f;
		alphaKey[0].time = 0.0f;
		alphaKey[1].alpha = 0.0f;
		alphaKey[1].time = 1.0f;

		gradient.SetKeys(colorKey, alphaKey);
	}

	void Update () {
		//camera.backgroundColor = gradient.Evaluate(Time.time % 1);
	}
}
