using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseReloadShoot : BaseShoot 
{
	public bool _hasInfiniteAmmo;
	public int _ammo;
	public int _maxClipSize;
	public int _currentClip;
	[SerializeField] private float _reloadDuration;

	private float _reloadTime;

	public override void Shoot()
	{
		if(_currentClip > 0)
		{
			base.Shoot();
			_currentClip--;
		}
		else if(_ammo > 0)
		{
			_reloadTime += _reloadDuration;
		}
		else if(_hasInfiniteAmmo)
		{
			_reloadTime += _reloadDuration;
		}
		else
		{
			Debug.Log(_objShooting + "is out of ammo");
		}
	}

	private void Reload()
	{
		if(_ammo > _maxClipSize)
		{
			_ammo -= _maxClipSize;
			_currentClip = _maxClipSize;
		}
	}
}
