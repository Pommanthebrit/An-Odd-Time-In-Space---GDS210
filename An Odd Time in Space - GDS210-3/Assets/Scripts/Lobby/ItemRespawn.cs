using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour {

	Transform initialPos;
	Rigidbody _Rb;

	void Start () {
		initialPos = new GameObject ("InitialPosition").transform;
		initialPos.position = transform.position;

		_Rb = GetComponent<Rigidbody> ();
	}
		
	void OnCollisionEnter (Collision collider) {
		//Will only die if eaten by GarbageBot
		if (collider.gameObject.tag == "Garbage") {
			Invoke ("Respawn", 0.1f);
		}
	}

	void Respawn () {
		//Kills all momentum and respawns in original position
		_Rb.velocity = Vector3.zero;
		_Rb.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.identity;
		transform.position = initialPos.position;
	}
}