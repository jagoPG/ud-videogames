using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reaction : MonoBehaviour 
{

	public int uid;

	public abstract void Init ();

	public abstract void React();

	protected abstract void SpecificInit ();

	protected abstract void ImmediateReation();
}
