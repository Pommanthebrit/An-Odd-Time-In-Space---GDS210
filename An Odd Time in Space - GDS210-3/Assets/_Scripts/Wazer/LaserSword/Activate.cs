using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour {

	public Material Purple;

	// Use this for initialization
	void Start () {
		Material[] previousMaterials = GetComponent<MeshRenderer> ().materials;
		previousMaterials [3] = Purple;
		GetComponent<MeshRenderer> ().materials = previousMaterials;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
