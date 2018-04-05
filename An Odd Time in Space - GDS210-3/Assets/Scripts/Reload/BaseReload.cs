using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseReload : ScriptableObject
{
	public IReload _objReloading;

	protected abstract void CompleteReload();
}