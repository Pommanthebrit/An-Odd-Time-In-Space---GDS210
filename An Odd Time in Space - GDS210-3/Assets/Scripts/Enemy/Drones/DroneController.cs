using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : BaseEnemyController, IReload
{
	// Shooting Variables.
	[Header("Drone Shooting")]
	[SerializeField] protected GameObject _projectilePrefab;
	[SerializeField] protected float _shootDelay;
	[SerializeField] protected BaseReload _reloadingMechanism;

	// Audio Variables.
	[Header("Drone Audio")]
	[SerializeField] protected AudioClip _hoverSound;
	protected AudioSource _audioSource;

	// Instantiates a projectile.
	public virtual void Shoot()
	{
		Instantiate(_projectilePrefab, transform.position, transform.rotation).GetComponent<Projectile>()._source = this.gameObject;
		Invoke("Shoot", _shootDelay); // Repeats method.
	}

	// Initialsation.
	protected override void Start ()
	{
		base.Start (); // Does parent actions.
		Invoke("Shoot", _shootDelay);
	}
}