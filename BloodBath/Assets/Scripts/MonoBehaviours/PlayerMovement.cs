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
	private Transform transform;
	private Vector2 DeltaForce;
	private Rigidbody2D RigidBody;
	private Animator Anim;
	private SpriteRenderer Sprite;
	private PolygonCollider2D verticalCollider;
	private BoxCollider2D horizontalCollider;

	private static PlayerMovement instance;

	public float Speed = 2;

	// Popup menu
	private bool isMenuShowed;

	// Number of items in front of the character
	private static int itemsInFront;

	// Interaction
	Interactable currentInteractable;
	Collider2D interactableGameObject;


	public static PlayerMovement getInstance()
	{
		return instance;	
	}

	public void MovePlayer(float x, float y) {
		Vector2 newPosition = new Vector2 ();
		newPosition.Set(x, y);
		verticalCollider.attachedRigidbody.position = newPosition;
	}

	private void Awake()
	{
		if (instance == null) {
			instance = this;
			transform = GetComponent<Transform> ();
			Anim = GetComponent<Animator> ();
			RigidBody = GetComponent<Rigidbody2D> ();
			Sprite = GetComponent<SpriteRenderer> ();
			verticalCollider = GetComponent<PolygonCollider2D> ();
			horizontalCollider = GetComponentInChildren<BoxCollider2D> ();
		}
	}

	private void Start ()
	{
		itemsInFront = 0;
		this.isMenuShowed = false;
		RigidBody.gravityScale = 0;
		RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	private void Update ()
	{
		if (currentInteractable != null && Input.GetKeyDown (KeyCode.E)) {
			currentInteractable.Interact ();

			if (interactableGameObject != null) {
				if (interactableGameObject.tag == "Chest") {
					Animator animator = interactableGameObject.GetComponentInParent<Animator> ();
					animator.SetBool ("isOpened", true);
				}
			}
		}

		// Enable inventory
		if (Input.GetKeyDown (KeyCode.I)) {
			if (this.isMenuShowed) {
				this.isMenuShowed = false;
				Inventory.GetInstance ().HideInventory ();
			} else {
				this.isMenuShowed = true;
				Inventory.GetInstance ().ShowInventory ();
			}
		}

		// Move in inventory
		if (this.isMenuShowed) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Inventory.GetInstance ().moveUp ();
			} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
				Inventory.GetInstance ().moveDown ();
			}
		}

		// Animation transition
		if (!this.isMenuShowed) {
			CheckInput ();
			MakeAnimationTransition ();
		}
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Passive Character" || collider.tag == "Item" || collider.tag == "Chest" || collider.tag == "Dynamic Obstacle") {
			Debug.Log ("Set interactable");
			currentInteractable = collider.GetComponent<Interactable> ();
			interactableGameObject = collider;
		}
		if (collider.tag == "Decoration" && collider.isTrigger) {
			itemsInFront = itemsInFront + 1;
			Sprite.sortingLayerName = "Player Hidded";
		}
		if (collider.tag == "Entrance") {
			collider.GetComponent<Interactable> ().Interact();
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Passive Character") {
			currentInteractable = null;
		}
		if (collider.tag == "Decoration" && collider.isTrigger) {
			itemsInFront = itemsInFront - 1;
			if (itemsInFront == 0) {
				Sprite.sortingLayerName = "Player";
			}
		}
	}
		
	/**
	 * Check movement 
	 */
	private void CheckInput()
	{
		var HorizontalInput = Input.GetAxisRaw ("Horizontal");
		var VerticalInput = Input.GetAxisRaw ("Vertical");

		DeltaForce = new Vector2 (HorizontalInput, VerticalInput);
		CalculateMovement (DeltaForce * Speed);
	}
		
	private void CalculateMovement(Vector2 PlayerForce)
	{
		RigidBody.velocity = Vector2.zero;
		RigidBody.AddForce (PlayerForce, ForceMode2D.Impulse);
	}
		
	private void MakeAnimationTransition()
	{
		if (Input.GetKey (KeyCode.W)) {
			Anim.SetInteger ("key", 1);
			Anim.SetBool ("hold", true);
			DisableHorizontalCollider ();
		} else if (Input.GetKey (KeyCode.S)) {
			Anim.SetInteger ("key", 2);
			Anim.SetBool ("hold", true);
			DisableHorizontalCollider ();
		} else if (Input.GetKey (KeyCode.A)) {
			Anim.SetInteger ("key", 3);
			Anim.SetBool ("hold", true);
			EnableHorizontalCollider ();
		} else if (Input.GetKey (KeyCode.D)) {
			Anim.SetInteger ("key", 4);
			Anim.SetBool ("hold", true);
			EnableHorizontalCollider ();
		} else {
			Anim.SetBool ("hold", false);
		}
	}

	private void EnableHorizontalCollider()
	{
		this.horizontalCollider.enabled = true;
		this.verticalCollider.enabled = false;
	}

	private void DisableHorizontalCollider()
	{
		this.horizontalCollider.enabled = false;
		this.verticalCollider.enabled = true;
	}
}
