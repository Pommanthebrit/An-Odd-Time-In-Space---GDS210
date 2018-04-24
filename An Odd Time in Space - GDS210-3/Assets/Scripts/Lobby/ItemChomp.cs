using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChomp : MonoBehaviour {

	Animator chompAnim;
	ParticleSystem chompPT;

	void Start () {
		chompAnim = GetComponent<Animator> ();
		chompPT = GetComponent<ParticleSystem> ();
	}
	
	void OnCollisionEnter (Collision collider) {
		//Particles for eating items
		if (collider.gameObject.tag == "Item") {
			Invoke ("ChompItem", 0.01f);
		}
	}

	void ChompItem () {
		chompAnim.SetTrigger ("Chomp");
		chompPT.Emit (40);
	}
}
