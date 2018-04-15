using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATA_ShootingMechanic", menuName = "Shooting Mechanisms/Auto Random Projectile")]
public class RandomProjectileAutoShoot : SimpleAutoShoot 
{
	[SerializeField] private GameObject[] _projectileList;

	public override void Shoot()
	{
		base.Shoot();

		_projectilePrefab = _projectileList[Random.Range(0, _projectileList.Length)];
	}
}
