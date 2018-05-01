using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOutOfBound : MonoBehaviour {

	[SerializeField] private GameObject destroyPT;
	AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision collider) {
		//Particles for eating items
		if (collider.gameObject.tag == "Item") {
			Invoke ("KillItem", 0.01f);
		}
		if (collider.gameObject.tag == "Letter") {
			Invoke ("KillItem", 0.01f);
			Destroy (collider.gameObject);
		}
	}

	void KillItem () {
		_audioSource.Play ();
		Instantiate (destroyPT, GetComponent<Collider>().transform.position, Quaternion.identity);
	}
}