using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourOut : MonoBehaviour {

	public GameObject myFilling;
	public Transform[] pourSpawn;
	public List<GameObject> amountPourable = new List<GameObject>();
	public ParticleSystem pourEmit;

	void Start () {
	//	ParticleSystem.EmissionModule emit = pourEmit.emission;
		pourEmit.Stop();
		//emit.enabled = false;
	}

	void Update () {
		//If object is upside down, instantiates pour cubes prefab up to limit of 30, then destroys the oldest
		if (Vector3.Dot(transform.up, Vector3.down) > 0f) {
			if (amountPourable.Count < 30) {
				amountPourable.Add ((GameObject)Instantiate (myFilling, pourSpawn [Random.Range (0, pourSpawn.Length)].position, Quaternion.identity));
				if (!pourEmit.isPlaying) {
					pourEmit.Play ();
				}
			} else {
				amountPourable.Add ((GameObject)Instantiate (myFilling, pourSpawn [Random.Range (0, pourSpawn.Length)].position, Quaternion.identity));
				Destroy (amountPourable [0]);
				amountPourable.RemoveAt (0);
				if (!pourEmit.isPlaying) {
					pourEmit.Play ();
				}
			}
		}
		if (Vector3.Dot (transform.up, Vector3.down) < 0f) {
			if (pourEmit.isPlaying) {
				pourEmit.Stop ();
			}
		}
	}
}