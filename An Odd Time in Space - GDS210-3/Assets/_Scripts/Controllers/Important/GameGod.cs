using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameGod : MonoBehaviour
{
	[SerializeField] private AudioClip[] _musicClips;
	public int _score;
	private int _highscore;
	//private AudioSource _myAudioSource; // <<< AUDIO

	public int _currentEnemyCount;

	void Start()
	{
		
//		if(GameObject.FindGameObjectWithTag("GameGod") != null)
//			Destroy (this.gameObject);
//		else
//			DontDestroyOnLoad(this.gameObject);

		//_myAudioSource = GetComponent<AudioSource>(); // <<< AUDIO
		// TODO: Add music functionality. (Possibly between scenes.)
	}

	public void AddScore(int score)
	{
		_score += score;

        print(_score);
		// TODO: Create score UI effect. (Possible implementation of a UiGod script?)
		Debug.Log(_score);
	}

	bool TestNewHighscore()
	{
		if(_highscore < _score)
		{
			_highscore = _score;
			return true;
		}
		else
			return false;
	}

	void LoadSceneByIndex(int index)
	{
		PreLoadSceneAction();
		SceneManager.LoadScene(index);
	}

	void LoadSceneByName(string sceneName)
	{
		PreLoadSceneAction();
		SceneManager.LoadScene(sceneName);
	}

	void PreLoadSceneAction()
	{
		SaveHighscore();
		// TODO Play exit scene noise and effects.
	}

	void StartSceneAction()
	{
		LoadHighscore();
		// TODO Play enter scene noise and effects.
	}

	void SaveHighscore()
	{
		if(TestNewHighscore())
		{
			PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, _highscore);
		}
	}

	void LoadHighscore()
	{
		_highscore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);
	}

	void GameOver()
	{
		TestNewHighscore();
		// TODO: Display gameover menu
	}
}
