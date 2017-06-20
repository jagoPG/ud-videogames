using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlaySoundReaction : Reaction {

	public AudioClip open;

	protected override void SpecificInit()
	{
	}

	protected override void ImmediateReaction()
	{
		Debug.Log ("Play sound reaction");

		SoundManager.GetInstance ().PlaySound (open);
	}
}
