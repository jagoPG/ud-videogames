using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour {

	public float xOffset;
	public float yOffset;
	public GameObject destiny;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			Vector2 destinyPosition = destiny.GetComponent<Transform> ().position;
			Vector2 newPosition = new Vector2 ();
			newPosition.Set (
				destinyPosition.x + xOffset,
				destinyPosition.y + yOffset
			);
			collider.attachedRigidbody.position = newPosition;
		}
	}
}
