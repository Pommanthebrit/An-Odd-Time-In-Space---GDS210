﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemiDroneSpawner : BaseDemiSpawner
{
	[Header("Movement")]
	[SerializeField] private float _maxVerticalDisTeleport;
	[SerializeField] private float _timeTillVerticalTeleport;

	[Header("Spawn Effect")]
	[SerializeField] private float _spawnEffectDuration;
	[SerializeField] private GameObject _spawnEffectPrefab;
	private GameObject _player;
	private Vector3 _startPos;

	protected override void Awake()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		_startPos = transform.position;

		base.Awake();
	}

	protected override void Start()
	{
		StartCoroutine(VerticalTeleport());

		StartCoroutine(ControlSpawning());

		base.Start();
	}

	protected override void CheckAndSetupEnemy(GameObject obj)
	{
		base.CheckAndSetupEnemy(obj);

		DroneController drone = obj.GetComponent<DroneController>();
		drone._target = _player.transform;
	}

	private void FixedUpdate()
	{
		transform.LookAt(_player.transform, Vector3.up);
		transform.Translate(5f * Time.fixedDeltaTime, 0f, 0, Space.Self);
	}

	IEnumerator VerticalTeleport()
	{
		while(true)
		{
			transform.position = new Vector3(transform.position.x, _startPos.y, transform.position.z) + new Vector3(0, Random.Range(-_maxVerticalDisTeleport, _maxVerticalDisTeleport));

			yield return new WaitForSeconds(_timeTillVerticalTeleport);
		}
	}

	IEnumerator ControlSpawning()
	{
		// FIXME: Will create effect however no object if object pool is totaly in use.

		yield return new WaitForSeconds(_spawnRate);

		// Repeats indefinetly;
		while(true) {
			print("Went Through");
			// Creates spawn effect.
			GameObject spawnEffect = Instantiate(_spawnEffectPrefab, transform.position, transform.rotation);

			// Stops code from going further if spawn effect is still active.
			while(spawnEffect != null) {
				yield return null;
			}

			print("Went Through Again");

			yield return new WaitForSeconds(_spawnRate);
		}

	}
}