using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Scriptable Object: Creatable via asset menu.
 * 
 */
[CreateAssetMenu(fileName = "DATA_ShootingMechanic", menuName = "Shooting Mechanisms/Random Auto Shoot")]
public class RandomAutoShoot : SimpleAutoShoot 
{
	[Header("Randomised Shoot Delay")]
	[SerializeField] private float _maxShootDelay;
	[SerializeField] private float _minShootDelay;

	// Randomise shoot delay between range.
	void RandomiseShootDelay()
	{
		_shootDelay = Random.Range(_minShootDelay, _maxShootDelay);
	}

	public override void Shoot()
	{
		base.Shoot();

		RandomiseShootDelay();
	}
}
