using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflection : MonoBehaviour {

	public bool collision;
	public float numBounces;

	void OnCollisionEnter(collision : Collision)
	{
		var contact : ContactPoint;
		if(numBounces > 0  (collision.gameObject.layer != 8))
		{
			contact = collision.contacts[0];
			var dot : float = Vector3.Dot(contact.normal, (-transform.forward));
			dot *= 2;
			reflection = contact.normal * dot;
			reflection = reflection + transform.forward;
			rigidbody.velocity = rigidbody.TransformDirection(reflection.normalized * 15.0);
			numBounces -= 1;
		}
	}
}