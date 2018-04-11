using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseReload : ScriptableObject
{
	// Variable for references any class that can reload.
	public IReload _objReloading;
	public bool _reloadPaused;

	protected abstract void CompleteReload();

	public abstract void ProgressReload ();

	public abstract void UpdateReload (int _currentClip);
}