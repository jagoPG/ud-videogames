using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TeleportCharacterReaction : Reaction {
	
	public GameObject target;
	public float offsetX;
	public float offsetY;

	protected override void SpecificInit()
	{

	}

	protected override void ImmediateReaction()
	{
		if (target == null) {
			return;
		}

		PlayerMovement.getInstance ().MovePlayer (target.transform.position.x + offsetX, target.transform.position.y + offsetY);

		if (offsetX > 0) {
			PlayerMovement.getInstance ().FreezePlayer ();
			PlayerMovement.getInstance ().LookRight ();
			PlayerMovement.getInstance ().UnfreezePlayer ();
		} else if (offsetX < 0) {
			PlayerMovement.getInstance ().LookLeft ();
		}
	}
}
