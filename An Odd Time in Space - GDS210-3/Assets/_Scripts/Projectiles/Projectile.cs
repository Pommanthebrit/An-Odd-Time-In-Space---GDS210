using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public abstract class Projectile : MonoBehaviour {
	
	[Header("Audio")]
	[SerializeField] protected AudioClip _birthClip;
	//Moved death audio to be paired with the death particle instantiation
	//[SerializeField] protected AudioClip _deathClip;

	[Header("Other")]
	[SerializeField] private float _lifeSpan;
	[HideInInspector] public GameObject _source;
    [HideInInspector] public Transform _targetTransform;
	protected AudioSource _audioSource;
	protected Rigidbody _rb;

	// Initialisation.
	protected virtual void Start () 
	{
		_rb = GetComponent<Rigidbody>();
		_audioSource = GetComponent<AudioSource> ();
		_audioSource.PlayOneShot(_birthClip);

        transform.LookAt(_targetTransform);

		Invoke ("Die", _lifeSpan);
	}

	// Method Setup.
	protected abstract void Move();

	protected virtual void Die()
	{
		Destroy(gameObject);
	}

	protected abstract void OnCollisionEnter(Collision col);
}
