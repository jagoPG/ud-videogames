using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private static SoundManager instance;
	public AudioSource fxPlayer;


	public static SoundManager GetInstance()
	{
		return instance;
	}

	public void PlaySound(AudioClip clip)
	{
		fxPlayer.clip = clip;
		fxPlayer.loop = false;
		fxPlayer.Play ();
	}

	private void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
	}
}
