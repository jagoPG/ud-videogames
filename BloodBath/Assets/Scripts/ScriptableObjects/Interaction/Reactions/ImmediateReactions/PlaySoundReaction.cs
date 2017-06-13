using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlaySoundReaction : Reaction {

	public AudioClip open;
	public AudioSource audio;

	protected override void SpecificInit()
	{
	}

	protected override void ImmediateReaction()
	{
		Debug.Log ("Play sound reaction");

		Debug.Log ("Sound length: " + open.length);
		audio.clip = open;
		audio.enabled = true;
		audio.Play ();
	}
}
