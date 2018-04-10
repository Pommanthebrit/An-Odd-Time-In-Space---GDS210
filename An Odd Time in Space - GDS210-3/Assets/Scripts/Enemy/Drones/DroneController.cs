using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DroneController : BaseEnemyController, IReload
{
	#region "||||| Basic Shooting Variables |||||"
	[Header("Drone Shooting")]
	[SerializeField] protected GameObject _projectilePrefab;

	[Tooltip("Time it takes until next shot is ready. (NOT RELOAD TIME)")]
	[SerializeField] protected float _shootDelay;

	[Tooltip("Select reload mechanism. To create a reload mechanism go to 'Assets/Create/Reload Mechanisms'")]
	[SerializeField] protected BaseReload _reloadingMechanism;
	#endregion



	#region "||||| Audio Settings |||||"
	[Header("Drone Audio")]

	//TODO: Setup Audio.

	[Tooltip("A sound that will consitently play.")]
	[SerializeField] protected AudioClip _hoverSound;

	protected AudioSource _audioSource;
	#endregion



	#region "||||| Movement Variables |||||"
	[Header("Movement")]

	[Tooltip("Target of which the drone will orbit around.")]
	public Transform _target;

	[Tooltip("Determines inital movement (Left or Right).")]
	[SerializeField] protected bool _moveRight;

	[SerializeField] protected float _speed;

	// Velocity that will be added after all changes to velocity have been calculated.
	protected Vector3 _velToAdd;
	#endregion

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
		Invoke("Shoot", _shootDelay); // Shoots in "_shootDelay" seconds.
	}

	protected virtual void FixedUpdate()
	{
		_velToAdd = Vector3.zero; // Resets velocity ready to be manipulated.

		// Movement steps.
		CalculateMovement();
		Rotate();
		Move();
	}

	// Rotate to look at target pos.
	protected virtual void Rotate()
	{
		_rb.MoveRotation(Quaternion.LookRotation((_target.position - transform.position).normalized, Vector3.up));
	}

	// Calculates movement before applying it.
	/* NOTE:
	 * This was created simiply due to complication when trying to edit velocity multiple times in one frame.
	 * It allows multiple edits. It also allows for easy inhertiance capabilities.
	 */
	protected virtual void CalculateMovement()
	{
		if (_moveRight)
			_velToAdd = transform.right * _speed;
		else
			_velToAdd = -transform.right * _speed;
	}

	// Applies movement.
	protected virtual void Move()
	{
		_rb.velocity = _velToAdd;
	}
}