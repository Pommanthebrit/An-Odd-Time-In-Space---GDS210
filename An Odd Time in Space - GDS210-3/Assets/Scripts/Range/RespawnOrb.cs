using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOrb : MonoBehaviour {

	GameGod _Gg;
	public bool respawnOrbTouched = false;
	public ParticleSystem orbOnEmit;

	void Start () {
		_Gg = FindObjectOfType<GameGod> ();
		orbOnEmit.Stop ();
	}

	//Resets ball and club positions, sets score back to 0
	public void OrbOn () {
		respawnOrbTouched = true;
		_Gg._score = 0;
		if (!orbOnEmit.isPlaying) {
			orbOnEmit.Play ();
		}
	}

	public void OrbOff () {
		respawnOrbTouched = false;
		if (orbOnEmit.isPlaying) {
			orbOnEmit.Stop ();
		}
	}
}