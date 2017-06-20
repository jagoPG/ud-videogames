using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FastFadeInReaction : Reaction {

	protected override void ImmediateReaction ()
	{
		FadeController.GetInstance ().FastFadeIn ();
		PlayerMovement.getInstance ().UnfreezePlayer ();
	}
}
