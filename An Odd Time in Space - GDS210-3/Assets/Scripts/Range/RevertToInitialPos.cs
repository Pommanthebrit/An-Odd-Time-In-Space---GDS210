using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertToInitialPos : MonoBehaviour {

	RespawnOrb respawnOrb;
	Rigidbody _Rb;
	public Transform initialPos;

	void Start () {
		respawnOrb = FindObjectOfType<RespawnOrb> ();
		_Rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (respawnOrb.respawnOrbTouched == true) {
			_Rb.velocity = Vector3.zero;
			_Rb.angularVelocity = Vector3.zero;
			transform.rotation = Quaternion.identity;
			transform.position = initialPos.position;
		}
	}
}