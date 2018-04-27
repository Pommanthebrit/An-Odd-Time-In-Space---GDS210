using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

/* BaseShoot is a scriptable object and can be created from the create asset menu.
 * Controls basic shooting setting (ready for inheritance).
 * Does not shoot on its own.
 */
[CreateAssetMenu(fileName = "DATA_ShootingMechanism", menuName = "Shooting Mechanisms/BaseShoot", order = 1)] // Creates menu item.
public class BaseShoot : ScriptableObject
{
	#region "Base Settings"
	[Header("Projectile")]

	[Tooltip("The projectile which will be spawned on the Shoot fucntion.")]
	[SerializeField] protected GameObject _projectilePrefab;

	[Tooltip("The location of where the projectile will spawn")]
	public GameObject _projectileSpawnPoint;
	private Vector3 _projectileSpawnPos;

	[Tooltip("Time it takes until next shot is ready. (NOT RELOAD TIME)")]
	public float _shootDelay;
	#endregion

	#region "Effects"
	[Header("Effects")]

	[Tooltip("This sound clip will play upon firing and is attached to the shooter.")]
	[SerializeField] protected AudioClip _shootSound;

	[Tooltip("This will be instantiate at the _projectileSP at relative rotation")]
	[SerializeField] private GameObject _shootEffect;
	#endregion


	#region "Other Variables"
	protected bool _canShoot = true;

	// References.
	protected GameObject _parentObj;
	protected IShoot _parentScript; // Interface that implements shooting critera (See IShoot for more details)

	// Alarms.
	[HideInInspector] public float _currentTime;
	[HideInInspector] public float _shootReadyTime;
	#endregion

	// Setups the shooting mechanic.
	public virtual void Setup(GameObject parentObj)
	{
		_parentObj = parentObj;
		_parentScript = _parentObj.GetComponent<IShoot>();
		_projectileSpawnPos = _projectileSpawnPoint.transform.localPosition;
		_projectileSpawnPoint = new GameObject ("TRSF_ProjectileSP");
		_projectileSpawnPoint.transform.SetParent(_parentObj.transform);
		_projectileSpawnPoint.transform.localPosition = _projectileSpawnPos;
		// TODO: Remove redunant components (eg. IShoot());
	}

	// Calls every frame. Ticks time for timers.
	public virtual void Update()
	{
		_currentTime += Time.deltaTime;
		_projectileSpawnPoint.transform.rotation = _parentObj.transform.rotation;

		CheckAlarms();
	}

	// This functions serves as an event handler. (Handles timers eg. shoot ready time.)
	public virtual void CheckAlarms()
	{
		if(_shootReadyTime < _currentTime)
		{
			_canShoot = true;
		}

		// TODO: Upgrade alarm handler.
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
			Instantiate(_shootEffect, _projectileSpawnPoint.transform.position, _projectileSpawnPoint.transform.rotation);
			Instantiate(_projectilePrefab, _projectileSpawnPoint.transform.position, _projectileSpawnPoint.transform.rotation);

            if(_parentObj.GetComponent<Animator>() != null)
            {
                _parentObj.GetComponent<Animator>().SetTrigger("Shoot");
            }
//			_objShooting.MyAudioSource.PlayOneShot(_shootSound);
			// TODO: Finish sounds here.

			_canShoot = false;
			_shootReadyTime = _currentTime + _shootDelay;
		}
	}
}
