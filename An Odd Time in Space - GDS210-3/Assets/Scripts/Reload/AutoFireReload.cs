using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoFireReload", menuName = "Reload Mechanisms/Auto Fire", order = 1)] // Creates menu item.
[System.Serializable]
public class AutoFireReload : BaseReload
{
	[SerializeField] private float _reloadLength;
	private float _currentTime;

	// Initialisation.
	public AutoFireReload(IReload objToReload, float reloadLength)
	{
		_objReloading = objToReload;
		_reloadLength = reloadLength;
	}

	// Called on every update.
	public virtual void ProgressReload()
	{
		// Advance time.
		_currentTime += Time.deltaTime;

		// Check time.
		if(_currentTime == _reloadLength)
		{
			CompleteReload();
		}
	}

	// Completes the reload process.
	protected override void CompleteReload ()
	{
		_objReloading.Shoot();
		_currentTime = 0;
	}
}
