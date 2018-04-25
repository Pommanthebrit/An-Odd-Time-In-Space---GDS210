using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOrb : MonoBehaviour {

	public bool respawnOrbTouched = false;

	public void OrbOn () {
		respawnOrbTouched = true;
	}

	public void OrbOff () {
		respawnOrbTouched = false;
	}
}