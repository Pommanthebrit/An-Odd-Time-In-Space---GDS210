using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAttach : MonoBehaviour {

	public Transform attachTo;
	
	void FixedUpdate () {
		transform.position = attachTo.transform.position;
		transform.rotation = attachTo.transform.rotation;
	}
}