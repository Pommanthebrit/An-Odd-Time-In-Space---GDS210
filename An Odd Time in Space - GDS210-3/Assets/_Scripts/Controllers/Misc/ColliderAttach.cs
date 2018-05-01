using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAttach : MonoBehaviour {

	public Transform attachTo;
	
	void Update () {
		transform.position = attachTo.transform.position;
	}
}