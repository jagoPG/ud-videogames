using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SatisfyConditionReaction : Reaction {

	public Condition condition;
	public string description;

	protected override void SpecificInit()
	{

	}

	protected override void ImmediateReaction()
	{
		condition.isSatisfied = true;
	}
}
