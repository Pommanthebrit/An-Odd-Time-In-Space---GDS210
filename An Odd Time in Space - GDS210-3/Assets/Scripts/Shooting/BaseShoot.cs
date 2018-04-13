using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseShoot
{
	[SerializeField] protected GameObject _projectilePrefab;
	[SerializeField] protected AudioClip _shootSound;
	[SerializeField] protected int _shootDelay;

	[SerializeField] protected Transform _projectileSpawnPos;
	private bool _canShoot;

	protected IShoot _objShooting;

	private float _currentTime;
	private float _shootReadyTime;


	public virtual void Setup(IShoot objShooting)
	{
		_objShooting = objShooting;
	}

	public virtual void Update()
	{
		_currentTime += Time.deltaTime;

		CheckAlarms();
	}

	public virtual void CheckAlarms()
	{
		if(_shootReadyTime < _currentTime)
		{
			_canShoot = true;
		}
	}

	public virtual void Shoot()
	{
		if(_canShoot)
		{
			_objShooting.CreateObj(_projectilePrefab, _projectileSpawnPos.position);
			_objShooting.MyAudioSource.PlayOneShot(_shootSound);

			_canShoot = false;
			_shootReadyTime = _currentTime + _shootDelay;
		}
	}

//	protected virtual void EnableShooting()
//	{
//		Debug.Log(_canShoot);
//	}
}
