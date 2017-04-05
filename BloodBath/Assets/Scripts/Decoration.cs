using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour
{
	public GameObject current;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//print ("Enter: " + collider.isTrigger);

		if (collider.tag == "Player" && collider.isTrigger) {
			//collider.attachedRigidbody.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		//print ("Exit: " + collider.isTrigger);

		if (collider.tag == "Player") {
			//collider.attachedRigidbody.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
		}
	}
}
