using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerScript : MonoBehaviour 
{
	public static ObjectPoolerScript current;
	public GameObject _currentPooledObject;
	public int _pooledAmount;
	public bool _willGrow = false;

	List<GameObject> _pooledObjects;

	void Awake()
	{
		current = this;
	}


	void Start()
	{
		_pooledObjects = new List<GameObject>();
		for(int index = 0; index < _pooledAmount; index++)
		{
			AddNewObject();
		}
	}

	public GameObject GetPooledObject()
	{
		foreach(GameObject obj in _pooledObjects)
		{
			if(!obj.activeInHierarchy)
			{
				return obj;
			}
		}

		if(_willGrow)
		{
			return AddNewObject();
		}

		return null;
	}

	GameObject AddNewObject()
	{
		GameObject obj = (GameObject)Instantiate(_currentPooledObject);
		obj.SetActive(false);
		_pooledObjects.Add(obj);
		return obj;
	}
}
