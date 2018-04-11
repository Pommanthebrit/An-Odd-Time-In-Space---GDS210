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
	private int _maxClipSize;
	private float _currentTime;

	// Called on every update.
	public override void ProgressReload()
	{
		// Advance time.
		_currentTime += Time.deltaTime;


		// Check time.
		if(_currentTime > _reloadLength)
		{
			Debug.Log("Time passed.");
			CompleteReload();
		}
	}

	public override void UpdateReload(int maxClipSize)
	{
		_maxClipSize = maxClipSize;
	}

	// Completes the reload process.
	protected override void CompleteReload()
	{
		_objReloading.CurrentClipSize = _maxClipSize;
		_objReloading.Shoot();
		_currentTime = 0;
	}
}
