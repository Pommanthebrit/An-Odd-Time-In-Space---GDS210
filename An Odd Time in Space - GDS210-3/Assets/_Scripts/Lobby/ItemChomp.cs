﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChomp : MonoBehaviour {

	Animator chompAnim;
	ParticleSystem chompPT;
	[SerializeField] ParticleSystem letterDiePT;
	AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource>();
		chompAnim = GetComponent<Animator> ();
		chompPT = GetComponent<ParticleSystem> ();
	}
	
	void OnCollisionEnter (Collision collider) {
		//Particles for eating items
		if (collider.gameObject.tag == "Item") {
			Invoke ("ChompItem", 0.01f);
		}
		if (collider.gameObject.tag == "Letter") {
			Invoke ("ChompItem", 0.01f);
			Instantiate(letterDiePT, collider.transform.position, Quaternion.identity);
			Destroy (collider.gameObject);
		}
	}

	void ChompItem () {
		_audioSource.Play (); //plays chomp audio
		chompAnim.SetTrigger ("Chomp");
		chompPT.Emit (40);
	}
}