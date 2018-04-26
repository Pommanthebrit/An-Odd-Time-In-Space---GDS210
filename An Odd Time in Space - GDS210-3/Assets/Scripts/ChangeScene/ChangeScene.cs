using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class ChangeScene : MonoBehaviour {

	AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

	//Open new scene button with delay
	public void OpenSceneDelayed(string sceneName) {
		StartCoroutine("Load", sceneName);
	}

	IEnumerator Load(string sceneName) {
		_audioSource.Play ();
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene (sceneName);
	}
}