using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{

	[SerializeField]
	private Vector2 DeltaForce;
	private Rigidbody2D RigidBody;
	private Animator Anim;
	private BoxCollider2D BoxCollider;
	private SpriteRenderer Sprite;

	public float Speed = 2;

	// Conversation menu
	private bool canBeShown = false;
	private bool isConversationActive = false;

	void Awake()
	{
		Anim = GetComponent<Animator> ();
		RigidBody = GetComponent<Rigidbody2D> ();
		BoxCollider = GetComponent<BoxCollider2D> ();
		Sprite = GetComponent<SpriteRenderer> ();
	}

	void Start ()
	{
		TextManager.HideText ();
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
		}

		CheckDecorationOnTriggerEnter (collider);
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Passive Character") {
			this.canBeShown = false;
		}
		CheckDecorationOnTriggerExit (collider);
	}

	/* Check Decoration Triggers */
	void CheckDecorationOnTriggerEnter(Collider2D collider)
	{
		if (collider.tag == "Decoration" && collider.isTrigger) {
			Sprite.sortingLayerName = "Player Hidded";
		}
	}

	void CheckDecorationOnTriggerExit(Collider2D collider)
	{
		if (collider.tag == "Decoration" && collider.isTrigger) {
			Sprite.sortingLayerName = "Player";
		}
	}

	/* Check movement */
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
		if (!isConversationActive) {
			isConversationActive = true;
			TextManager.ShowText ();
		} else {
			isConversationActive = false;
			TextManager.HideText ();
		}
	}
}
