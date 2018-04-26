using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

	private AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider col)
	{
		print ("bounce");
		_audioSource.Play ();
	}
}
