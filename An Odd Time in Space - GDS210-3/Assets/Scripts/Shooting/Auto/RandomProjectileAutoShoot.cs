using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* RandomProjectileAutoShoot is a scritable object and can be created from the create asset menu.
 * This script fires a random projectile automatically. 
 * The projectiles are choosen from a predetermined list available for editing in the editor. 
 * The shoot times are defined by shootDelay (also in editor).
 * Inherits from SimpleAutoShoot.
 * Great to use on easy enemies.
 */
[CreateAssetMenu(fileName = "DATA_ShootingMechanic", menuName = "Shooting Mechanisms/Auto Random Projectile")]
public class RandomProjectileAutoShoot : SimpleAutoShoot 
{
	[Header("Projectile Types")]
	[SerializeField] private GameObject[] _projectileList;

	// Shoots specified projectile.
	public override void Shoot()
	{
		// Calls original shoot method.
		base.Shoot();

		// Chooses a random projectile for next shot.
		_projectilePrefab = _projectileList[Random.Range(0, _projectileList.Length)];
	}
}
