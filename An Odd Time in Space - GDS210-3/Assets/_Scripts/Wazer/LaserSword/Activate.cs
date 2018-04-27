using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour {

	public Material Purple;
	[SerializeField] ParticleSystem swordPT;

	public void SwordActivate () {
		Material[] previousMaterials = GetComponent<MeshRenderer> ().materials;
		previousMaterials [3] = Purple;
		GetComponent<MeshRenderer> ().materials = previousMaterials;

		swordPT.Play ();
	}
}