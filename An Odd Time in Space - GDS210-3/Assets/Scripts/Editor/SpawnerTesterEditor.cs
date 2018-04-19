using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnerGod))]
public class SpawnerTesterEditor : Editor
{
	private SpawnerGod _spawnerGod;

	void OnEnable()
	{
		_spawnerGod = (SpawnerGod)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		if(GUILayout.Button("Change to Easy Difficulty"))
		{
			_spawnerGod.SwitchDifficulty (SpawnerGod.SpawnDifficulty.EASY);
		}

		if(GUILayout.Button("Change to Medium Difficulty"))
		{
			_spawnerGod.SwitchDifficulty (SpawnerGod.SpawnDifficulty.MEDIUM);
		}

		if(GUILayout.Button("Change to Hard Difficulty"))
		{
			_spawnerGod.SwitchDifficulty (SpawnerGod.SpawnDifficulty.HARD);
		}
	}
}
