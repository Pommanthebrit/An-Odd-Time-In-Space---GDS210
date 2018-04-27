using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidScript : MonoBehaviour {

	private Animator _animator;
	public AudioClip SoundToPlay;
	public float Volume;
	AudioSource _audio;
	public bool alreadyPlayed = false;

	// Use this for initialization
	void Start () 
	{
		_animator = GetComponent<Animator> ();
		_audio = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			_animator.SetBool ("Wave", true);
			_audio.PlayOneShot (SoundToPlay, Volume);
		}
		if (!alreadyPlayed) 
		{
			alreadyPlayed = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
