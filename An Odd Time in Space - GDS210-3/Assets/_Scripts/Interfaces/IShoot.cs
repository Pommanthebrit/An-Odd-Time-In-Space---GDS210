using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoot
{
	BaseShoot ShootingMechanism { get; set; }
	AudioSource MyAudioSource { get; set; }
	void CreateObj(GameObject obj, Vector3 pos);
}
