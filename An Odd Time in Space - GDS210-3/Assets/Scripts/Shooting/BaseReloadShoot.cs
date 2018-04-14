using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DATA_ShootingMechanism", menuName = "Shooting Mechanisms/Base Reload")]
public class BaseReloadShoot : BaseShoot, IShootMech
{
	public bool _hasInfiniteAmmo;
	public int _ammo;
	public int _maxClipSize;
	public int _currentClip;
	[SerializeField] private float _reloadDuration;

	private float _reloadTime;
	private bool _isReloading;

	public override void Shoot()
	{
		if(_currentClip > 0)
		{
			base.Shoot();
			_currentClip--;
		}
		else if(_ammo > 0)
		{
			StartReload();
		}
		else if(_hasInfiniteAmmo)
		{
			StartReload();
		}
		else
		{
			Debug.Log(_objShooting + "is out of ammo");
		}
	}

	public override void CheckAlarms()
	{
		base.CheckAlarms();

		if(_reloadTime < _currentTime && _isReloading)
		{
			FinishReload();
		}
	}

	public void StartReload()
	{
		_reloadTime += _reloadDuration;
		_isReloading = true;
	}

	public void FinishReload()
	{
		if(_ammo > _maxClipSize)
		{
			_ammo -= _maxClipSize;
			_currentClip = _maxClipSize;
		}
		else
		{
			_currentClip = _ammo;
			_ammo = 0;
		}

		_isReloading = false;
	}
}
