using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
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

	// Interaction
	Interactable currentInteractable = null;

	void Awake()
	{
		Anim = GetComponent<Animator> ();
		RigidBody = GetComponent<Rigidbody2D> ();
		BoxCollider = GetComponent<BoxCollider2D> ();
		Sprite = GetComponent<SpriteRenderer> ();
	}

	void Start ()
	{
		RigidBody.gravityScale = 0;
		RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Update ()
	{
		if (currentInteractable != null && Input.GetKeyDown (KeyCode.E)) {
			currentInteractable.Interact ();
		}

		CheckInput ();
		MakeAnimationTransition ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		print ("Player entered collider: " + collider.tag);

		if (collider.tag == "Passive Character" || collider.tag == "Item") {
			currentInteractable = collider.GetComponent<Interactable> ();
		}

		CheckDecorationOnTriggerEnter (collider);
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		print ("Player exited collider: " + collider.tag);

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
}
