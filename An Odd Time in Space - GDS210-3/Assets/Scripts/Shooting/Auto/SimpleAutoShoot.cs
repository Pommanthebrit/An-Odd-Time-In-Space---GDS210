using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Scriptable Object: Creatable via asset menu.
 * Shoots once on a timer.
 */
[CreateAssetMenu(fileName = "DATA_ShootingMechanism", menuName = "Shooting Mechanisms/Simple Auto")]
public class SimpleAutoShoot : BaseShoot
{
	// Checks if any set timers require actions.
	public override void CheckAlarms()
	{
		base.CheckAlarms();

		// Shoots as soon as a shot is ready to fire.
		if(_canShoot == true)
		{
			Shoot();
		}
	}
}
