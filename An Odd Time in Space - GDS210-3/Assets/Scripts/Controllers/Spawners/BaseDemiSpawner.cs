﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDemiSpawner : MonoBehaviour 
{
	public GameGod _gg;
	public float _spawnRate;

	public int _pooledObjAmount;
	public GameObject _pooledObj;
	public bool _canGrow;

	List<GameObject> _pooledObjects;

	protected virtual void Start()
	{
		_pooledObjects = new List<GameObject>();
		// Setup object pool.
		for(int index = 0; index < _pooledObjAmount; index++)
		{
			AddObjectToPool(_pooledObj);
		}
	}

	protected virtual void CheckAndSetupEnemy(GameObject obj)
	{
		if(obj.tag == "Enemy")
		{
			obj.GetComponent<BaseEnemyController>()._gg = _gg;
		}
	}

	// Returns a inactive pooledObject.
	public GameObject GetPooledObject()
	{
		foreach(GameObject obj in _pooledObjects)
		{
			if(!obj.activeInHierarchy)
				return obj;

			if(_canGrow)
				return AddObjectToPool(_pooledObj);
		}

		return null;
	}

	// Adds new object to pool.
	GameObject AddObjectToPool(GameObject _objToAdd)
	{
		GameObject obj = (GameObject)Instantiate(_objToAdd);
		_pooledObjects.Add(obj);
		CheckAndSetupEnemy(obj);
		obj.SetActive(false);
		return obj;
	}

	public virtual void AttemptSpawnObj()
	{
		GameObject obj = GetPooledObject();
		if(obj != null)
		{
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;
			obj.SetActive(true);
		}
	}

	// TODO: Create timer class and replace old timers.
}
