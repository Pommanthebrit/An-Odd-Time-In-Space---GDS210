using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Shoot
{
	[SerializeField] protected GameObject _projectilePrefab;
	[SerializeField] protected bool _infiniteAmmo = true;
	[SerializeField] protected int _ammo = 1;
	[HideInInspector] protected int _currentClipSize;
	[SerializeField] protected int _shootDelay;
	private bool _canShoot;
	private GameObject _myGameObject;

	public virtual void Shoot2()
	{
//		if(_myGameObject.GetComponent<IReload>() != null)
//			Debug.Log("Legend");
	}

	protected abstract void Reload();

	protected abstract void EnableShooting();
}
