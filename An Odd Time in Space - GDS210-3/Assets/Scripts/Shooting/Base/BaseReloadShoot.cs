using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DATA_ShootingMechanism", menuName = "Shooting Mechanisms/Base Reload")]
public class BaseReloadShoot : BaseShoot
{
	#region "Ammo Variables"
	[Header("Ammo")]

	public bool _hasInfiniteAmmo;

	[Tooltip("How much ammo this object has. (Not including clip)")]
	public int _ammo;
	#endregion


	#region "Reloading Variables"
	[Header("Reloading Settings")]

	[Tooltip("Sets how many bullets can be fired before a reload is required.")]
	public int _maxClipSize;

	[Tooltip("Current amount of bullets in clip.")]
	public int _currentClip;

	[Tooltip("How long it will take to reload in seconds.")]
	[SerializeField] private float _reloadDuration;

	// Other Variables.
	private float _reloadTime;
	private bool _isReloading;
	#endregion

	public override void Shoot()
	{
		/* Shoots if there is ammo left in the clip
		 * Reloads if there is no ammo in clip but there is ammo
		 * Reloads if there is no ammo in clip but there obj has infinite ammo
		 * Prints out of ammo if there is no ammo left at all.
		 */
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
			Debug.Log(_parentObj + "is out of ammo");
		}
	}

	public override void CheckAlarms()
	{
		base.CheckAlarms();

		// Finishes reload if time is up and if it was reloading in the first place.
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

	// Finishs reload.
	public void FinishReload()
	{
		// If enough ammo fill mag.
		if(_ammo > _maxClipSize)
		{
			_ammo -= _maxClipSize;
			_currentClip = _maxClipSize;
		}
		// If not enough ammo fill as much as you can
		else
		{
			_currentClip = _ammo;
			_ammo = 0;
		}

		_isReloading = false;
	}
}
