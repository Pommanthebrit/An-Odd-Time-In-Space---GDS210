using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourOut : MonoBehaviour {

	public GameObject myFilling;
	public Transform[] pourSpawn;

	void Update () {
		if (Vector3.Dot(transform.up, Vector3.down) > 0f) {
			Instantiate (myFilling, pourSpawn[Random.Range(0, pourSpawn.Length)].position, Quaternion.identity);
		}
	}
}