using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

	private static TextManager instance;
	public GameObject conversationText;

	void Awake ()
	{
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} if (instance != this) {
			Destroy (gameObject);
		}
	}

	public static void SetText(string text)
	{
		GUIText textLabel = instance.conversationText.GetComponentInChildren<GUIText>();	
		textLabel.text = text;
	}

	public static void ShowText()
	{
		print ("REACH SHOW");
		instance.conversationText.SetActive (true);
	}

	public static void HideText()
	{
		print ("REACH HIDE");
		instance.conversationText.SetActive (false);
	}
}
