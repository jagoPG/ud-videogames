using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Player : MonoBehaviour
{

	[SerializeField]
	private Vector2 DeltaForce;
	private Rigidbody2D RigidBody;
	private Animator Anim;
	private BoxCollider2D BoxCollider;

	public float Speed = 2;

	// Conversation menu
	public GameObject ConversationPanel;
	private bool canBeShown = false;
	private bool isConversationActive = false;

	void Awake()
	{
		Anim = GetComponent<Animator> ();
		RigidBody = GetComponent<Rigidbody2D> ();
		BoxCollider = GetComponent<BoxCollider2D> ();
	}

	void Start ()
	{
		ConversationPanel.SetActive (false);
		RigidBody.gravityScale = 0;
		RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.E) && this.canBeShown) {
			ManageConversation ();
		} else if (!isConversationActive) {
			CheckInput ();
			MakeAnimationTransition ();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Passive Character") {
			this.canBeShown = true;
		} else {
			this.canBeShown = false;
		}
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

	void MakeAnimationTransition()
	{
		if (Input.GetKey (KeyCode.W)) {
			Anim.SetInteger ("key", 1);
			Anim.SetBool ("hold", true);
		} else if (Input.GetKey (KeyCode.S)) {
			Anim.SetInteger ("key", 2);
			Anim.SetBool ("hold", true);
		} else if (Input.GetKey (KeyCode.A)) {
			Anim.SetInteger ("key", 3);
			Anim.SetBool ("hold", true);
		} else if (Input.GetKey (KeyCode.D)) {
			Anim.SetInteger ("key", 4);
			Anim.SetBool ("hold", true);
		} else {
			Anim.SetBool ("hold", false);
		}
	}
		
	void ManageConversation()
	{
		if (isConversationActive) {
			// !TODO manage conversation progress

			ConversationPanel.SetActive(isConversationActive = false);
		} else {
			ConversationPanel.SetActive (isConversationActive = true);
		}
	}
}
