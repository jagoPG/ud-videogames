using UnityEngine;

public abstract class Reaction : ScriptableObject 
{
	public void Init ()
	{
		SpecificInit ();
	}

	public void React(MonoBehaviour monoBehaviour)
	{
		ImmediateReaction ();
	}

	protected virtual void SpecificInit ()
	{}

	protected abstract void ImmediateReaction();
}
