using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour
{
	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player" && !collider.isTrigger) {
			collider.attachedRigidbody.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player Hidded";
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Player") {
			collider.attachedRigidbody.gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "Player";
		}
	}
}
