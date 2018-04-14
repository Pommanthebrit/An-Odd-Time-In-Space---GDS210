using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DATA_ShootingMechanism", menuName = "Shooting Mechanisms/BaseShoot", order = 1)] // Creates menu item.
public class BaseShoot : ScriptableObject
{
	#region "Base Settings"
	[Header("Base Shooting Settings")]

	[Tooltip("The projectile which will be spawned on the Shoot fucntion.")]
	[SerializeField] protected GameObject _projectilePrefab;

	[Tooltip("This sound clip will play upon firing and is attached to the shooter.")]
	[SerializeField] protected AudioClip _shootSound;

	[Tooltip("Time it takes until next shot is ready. (NOT RELOAD TIME)")]
	[SerializeField] protected int _shootDelay;

//	[SerializeField] protected Transform _projectileSpawnPos;
	protected bool _canShoot = true;
	#endregion

	#region "Other Variables"
	// References.
	protected GameObject _parentObj;
	protected IShoot _parentScript;

	// Alarms.
	protected float _currentTime;
	private float _shootReadyTime;
	#endregion

	// Setups the shooting mechanic.
	public virtual void Setup(GameObject parentObj)
	{
		_parentObj = parentObj;
		_parentScript = _parentObj.GetComponent<IShoot>();
	}

	// Calls every frame. Ticks time for timers.
	public virtual void Update()
	{
		_currentTime += Time.deltaTime;

		CheckAlarms();
	}

	// This functions serves as an event handler. (Handles timers eg. shoot ready time.)
	public virtual void CheckAlarms()
	{
		if(_shootReadyTime < _currentTime)
		{
			_canShoot = true;
		}
	}

	/* Creates projectile
	 * Plays audio
	 * Ensures shooting is disabled
	 * Sets timer
	 */
	public virtual void Shoot()
	{
		if(_canShoot)
		{
			// Creates the projectile at given position. (Consider Revising)
			_parentScript.CreateObj(_projectilePrefab, _parentObj.transform.position);
//			_objShooting.MyAudioSource.PlayOneShot(_shootSound);

			_canShoot = false;
			_shootReadyTime = _currentTime + _shootDelay;
		}
	}
}
