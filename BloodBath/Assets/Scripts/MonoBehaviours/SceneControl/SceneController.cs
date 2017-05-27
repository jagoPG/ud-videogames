using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public string startingSceneName = "Chapter1Scene";

	IEnumerator Start () {
		print ("Load scene " + startingSceneName);

		SceneManager.LoadScene (startingSceneName);
		yield return null;
		Scene newScene = SceneManager.GetSceneByName (startingSceneName);
		SceneManager.SetActiveScene (newScene);

		AllConditions.GetInstance ().Reset ();
	}
}
