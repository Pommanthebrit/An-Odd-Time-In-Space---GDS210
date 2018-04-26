using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePT : MonoBehaviour {

	public GameObject bounceParticle;

	void OnCollisionEnter (Collision collider) {
		//Creates particle which destroys self after running to completion
		if (collider.gameObject.tag == "Planets") {
			Instantiate (bounceParticle, collider.transform.position, Quaternion.identity);
		}
	}
}