using System.Collections;
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

	protected override void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		_startPos = transform.position;

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

	private void Update()
	{
		transform.LookAt(_player.transform, Vector3.up);
		transform.Translate(transform.right * Time.deltaTime);
	}

	IEnumerator VerticalTeleport()
	{
		while(true)
		{
			transform.position += new Vector3(0, Random.Range(-_maxVerticalDisTeleport, _maxVerticalDisTeleport));

			yield return new WaitForSeconds(_timeTillVerticalTeleport);
		}
	}

	IEnumerator ControlSpawning()
	{
		while(true)
		{
			// TODO: Add Drone Spawn Effect.

			yield return new WaitForSeconds(_spawnEffectDuration); // Temp.

			AttemptSpawnObj();

			yield return new WaitForSeconds(_spawnRate);
		}
	}
}
