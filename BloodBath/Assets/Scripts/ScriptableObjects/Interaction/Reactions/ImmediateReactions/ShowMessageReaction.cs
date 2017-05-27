using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShowMessageReaction : Reaction {

	public string message;

	protected override void SpecificInit()
	{
		
	}

	protected override void ImmediateReaction()
	{
		TextManager.GetInstance().SetText (message, 2, null);
	}
}
