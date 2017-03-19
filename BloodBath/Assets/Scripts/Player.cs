using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {

	[SerializeField]
	private Vector2 DeltaForce;
	private Rigidbody2D RigidBody;
	private Animator Anim;
	private BoxCollider2D BoxCollider;

	public float Speed = 2;

	void Awake()
	{
		Anim = GetComponent<Animator> ();
		RigidBody = GetComponent<Rigidbody2D> ();
		BoxCollider = GetComponent<BoxCollider2D> ();
	}

	void Start ()
	{
		RigidBody.gravityScale = 0;
		RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Update ()
	{
		CheckInput ();
	}

	void CheckInput()
	{
		var HorizontalInput = Input.GetAxisRaw ("Horizontal");
		var VerticalInput = Input.GetAxisRaw ("Vertical");

		DeltaForce = new Vector2 (HorizontalInput, VerticalInput);
		CalculateMovement (DeltaForce * Speed);
	}

	void CalculateMovement(Vector2 PlayerForce)
	{
		RigidBody.velocity = Vector2.zero;
		RigidBody.AddForce (PlayerForce, ForceMode2D.Impulse);
	}
}
