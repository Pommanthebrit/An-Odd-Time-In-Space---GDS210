using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour {

	public Material Purple;
	[SerializeField] ParticleSystem swordPT;
	AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

	public void SwordActivate () {
		Material[] previousMaterials = GetComponent<MeshRenderer> ().materials;
		previousMaterials [3] = Purple;
		GetComponent<MeshRenderer> ().materials = previousMaterials;

		swordPT.Play ();
		_audioSource.Play ();
	}
}