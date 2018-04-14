using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DATA_ShootingMechanism", menuName = "Shooting Mechanisms/Simple Auto")]
public class SimpleAutoShoot : BaseShoot
{
	public override void CheckAlarms()
	{
		base.CheckAlarms();

		if(_canShoot == true)
		{
			Shoot();
		}
	}
}
