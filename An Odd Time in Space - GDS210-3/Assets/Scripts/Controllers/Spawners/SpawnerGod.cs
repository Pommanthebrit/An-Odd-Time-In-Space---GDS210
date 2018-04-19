using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGod : MonoBehaviour 
{
	public enum SpawnDifficulty {EASY, MEDIUM, HARD};
	public SpawnDifficulty _currentSpawnDifficulty = SpawnDifficulty.EASY;

	private List<GameObject> _easySpawners;
	private List<GameObject> _mediumSpawners;
	private List<GameObject> _hardSpawners;

	void Start()
	{
		// Create new lists.
		_easySpawners = new List<GameObject>();
		_mediumSpawners = new List<GameObject>();
		_hardSpawners = new List<GameObject>();
		// Add Easy spawners.
		foreach(BaseDemiSpawner spawner in this.gameObject.GetComponentsInChildren<BaseDemiSpawner>())
		{
			switch(spawner.)
			{
			}
		}
		// Add Medium spawners.
		// Add Hard spawners.
	}
}
