using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make script editable in editor rather than a scriptable object.

[CreateAssetMenu(fileName = "AutoFireReload", menuName = "Reload Mechanisms/Auto Fire", order = 1)] // Creates menu item.
[System.Serializable]
public class AutoFireReload : BaseReload
{
	[SerializeField] private AudioClip _reloadSound;
	[SerializeField] private float _reloadLength;
	private int _currentClip;
	private float _currentTime;

	// Initialisation.
	public AutoFireReload(IReload objToReload, float reloadLength)
	{
		_objReloading = objToReload;
		_reloadLength = reloadLength;
	}

	// Called on every update.
	public override void ProgressReload()
	{
		if(!_reloadPaused)
		{
			// Advance time.
			_currentTime += Time.deltaTime;
		}


		// Check time.
		if(_currentTime > _reloadLength)
		{
			CompleteReload();
		}
	}

	public override void UpdateReload(int _currentClip)
	{
		
	}

	// Completes the reload process.
	protected override void CompleteReload()
	{
		_objReloading.Shoot();
		_currentTime = 0;
		_reloadPaused = true;
	}
}
