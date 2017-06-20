using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FastFadeOutReaction : Reaction {

	protected override void ImmediateReaction ()
	{
		PlayerMovement.getInstance ().FreezePlayer ();
		FadeController.GetInstance ().FastFadeOut ();
	}
}
