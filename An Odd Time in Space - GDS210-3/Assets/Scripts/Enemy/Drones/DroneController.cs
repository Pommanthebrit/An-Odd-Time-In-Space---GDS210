﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class DroneController : BaseEnemyController, IShoot
{
	#region "||||| Basic Shooting Variables |||||"
	// TODO: Create seperate "mechanic" for shooting which includes reload.
	[Header("Drone Shooting")]

	[Tooltip("Sets how many bullets can be fired before a reload is required.")]
	[SerializeField] private int _clipSize;
	private int _maxClipSize;
	public int CurrentClipSize{ get; set; }

	[SerializeField] protected GameObject _projectilePrefab;

	[Tooltip("Time it takes until next shot is ready. (NOT RELOAD TIME)")]
	[SerializeField] protected float _shootDelay;

	[Tooltip("test")]
//	[SerializeField] protected BaseReload _reloadingMechanism;
	public BaseShoot _shootingMechanism;
	[SerializeField] protected BaseReload _testl;

	public BaseShoot ShootingMechanism { get; set; }
	public AudioSource MyAudioSource { get; set; }
	#endregion

//	void OnEnable()
//	{
//		_shootingMechanism = ScriptableObject.CreateInstance<BaseShoot>();
//	}

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

	// Instantiates an Object at specified position.
	public virtual void CreateObj(GameObject obj, Vector3 pos)
	{
		Instantiate(obj, pos, transform.rotation);
	}


	// Initialsation.
	protected override void Start ()
	{
		base.Start(); // Does parent actions.
		Invoke("Shoot", _shootDelay); // Shoots in "_shootDelay" seconds.

		// Reloading.
		// Ensures reloading mechanism is setup to reload this drone.
//		_reloadingMechanism._objReloading = this.gameObject.GetComponent<DroneController>();
//		_reloadingMechanism.UpdateReload(_clipSize);
		CurrentClipSize = _clipSize;

		_shootingMechanism.Setup(this);
	}

	protected virtual void FixedUpdate()
	{
		_velToAdd = Vector3.zero; // Resets velocity ready to be manipulated.

		// Movement steps.
		CalculateMovement();
		Rotate();
		Move();
	}

	protected virtual void Update()
	{
		// Progress's reload mechanism.
		if(CurrentClipSize < 1)
		{
//			_reloadingMechanism.ProgressReload();
		}
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

	// TODO: Redo reload and shooting mechanics.
	// FIXME: TEMP Reloading and Shooting mechanicsms need fixing.
}