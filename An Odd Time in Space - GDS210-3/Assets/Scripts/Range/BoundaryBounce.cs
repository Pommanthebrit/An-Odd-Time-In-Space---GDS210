using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBounce : MonoBehaviour {

	public GameObject bounceParticle;

	void OnCollisionEnter (Collision collider) {
		Instantiate (bounceParticle, collider.transform.position, Quaternion.identity);
	}
}