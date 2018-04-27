using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnerGod : MonoBehaviour 
{
	public GameGod _gg;
	public enum SpawnDifficulty {EASY, MEDIUM, HARD};
	public SpawnDifficulty _currentSpawnDifficulty = SpawnDifficulty.EASY;

	[SerializeField] private int _maxEasyScore;
	[SerializeField] private int _maxMediumScore;

	private List<GameObject> _easySpawners;
	private List<GameObject> _mediumSpawners;
	private List<GameObject> _hardSpawners;
	private List<GameObject> _allSpawners;

	void Start()
	{
		// References
		_gg = GameObject.FindGameObjectWithTag("GameGod").GetComponent<GameGod>();

		// Create new lists.
		_easySpawners = new List<GameObject>();
		_mediumSpawners = new List<GameObject>();
		_hardSpawners = new List<GameObject>();
		_allSpawners = new List<GameObject> ();

		foreach(BaseDemiSpawner spawner in this.gameObject.GetComponentsInChildren<BaseDemiSpawner>(true))
		{
            spawner._gg = _gg;
			_allSpawners.Add(spawner.gameObject);

			switch(spawner._spawnerDifficulty)
			{
				// Add Easy spawners.
				case SpawnDifficulty.EASY:
					_easySpawners.Add(spawner.gameObject);
					break;

				// Add Medium spawners.
				case SpawnDifficulty.MEDIUM:
					_mediumSpawners.Add(spawner.gameObject);
					break;

				// Add Hard spawners.
				case SpawnDifficulty.HARD:
					_hardSpawners.Add(spawner.gameObject);
					break;
			}
		}
	}

	void Update()
	{
		if(_gg._score < _maxEasyScore)
		{
			SwitchDifficulty(SpawnDifficulty.MEDIUM);
		}
		else if(_gg._score < _maxMediumScore)
		{
			SwitchDifficulty(SpawnDifficulty.HARD);
		}
		else
		{
			// Win Condition?
		}
	}

	public void SwitchDifficulty(SpawnDifficulty difficulty)
	{
		foreach(GameObject spawner in _allSpawners)
		{
			spawner.SetActive(false);
		}

		switch(difficulty)
		{
		case SpawnDifficulty.EASY:
			foreach(GameObject spawner in _easySpawners)
			{
				_currentSpawnDifficulty = SpawnDifficulty.EASY;
				spawner.SetActive(true);
			}
			break;

		case SpawnDifficulty.MEDIUM:
			foreach(GameObject spawner in _mediumSpawners)
			{
				_currentSpawnDifficulty = SpawnDifficulty.MEDIUM;
				spawner.SetActive(true);
			}
			break;

		case SpawnDifficulty.HARD:
			foreach(GameObject spawner in _hardSpawners)
			{
				_currentSpawnDifficulty = SpawnDifficulty.HARD;
				spawner.SetActive(true);
			}
			break;
		}
	}
}
