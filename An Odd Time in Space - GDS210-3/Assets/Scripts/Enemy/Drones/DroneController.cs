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

	// Movement Variables.
	[Header("Movement")]
	public Transform _target;
	[SerializeField] protected float _speed;

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

	protected virtual void FixedUpdate()
	{
		Rotate();
		Move();
	}

	// Rotate to look at target pos.
	protected virtual void Rotate()
	{
		_rb.MoveRotation(Quaternion.LookRotation((_target.position - transform.position).normalized, Vector3.up));
	}

	protected virtual void Move()
	{
		_rb.velocity = transform.right * _speed;
	}
}