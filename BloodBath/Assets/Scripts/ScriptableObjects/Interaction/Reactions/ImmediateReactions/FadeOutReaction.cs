using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FadeOutReaction : Reaction {

	protected override void ImmediateReaction ()
	{
		PlayerMovement.getInstance ().FreezePlayer ();
		PlayerMovement.getInstance ().LookLeft ();
		FadeController.GetInstance ().FadeOut ();
	}
}
