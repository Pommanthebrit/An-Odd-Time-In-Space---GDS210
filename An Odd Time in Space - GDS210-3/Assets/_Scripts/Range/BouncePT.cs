﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePT : MonoBehaviour {

	[Header("Effects")]
	[SerializeField] AudioSource _audioSource;
	[SerializeField] AudioClip[] crashAudio;
	[SerializeField] GameObject bounceParticle;

	void OnCollisionEnter (Collision collider) {
		//Creates particle which destroys self after running to completion
		if (collider.gameObject.tag == "Planets" || collider.gameObject.tag == "Ball") {
			Instantiate (bounceParticle, collider.transform.position, Quaternion.identity);

			_audioSource.PlayOneShot (crashAudio[Random.Range (0, crashAudio.Length)]); 
		}
	}
}