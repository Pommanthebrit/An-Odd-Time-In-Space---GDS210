using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public abstract class Projectile : MonoBehaviour {
	
	[Header("Audio")]
	[SerializeField] protected AudioClip _birthClip;
	[SerializeField] protected AudioClip _deathClip;

	[Header("Other")]
	[SerializeField] private float _lifeSpan;
	[HideInInspector] public GameObject _source;
	protected AudioSource _audioSource;
	protected Rigidbody _rb;

	// Initialisation.
	protected virtual void Start () 
	{
		_rb = GetComponent<Rigidbody>();
		//_audioSource.PlayOneShot(_birthClip);

		Invoke ("Die", _lifeSpan);
	}

	// Method Setup.
	protected abstract void Move();

	protected virtual void Die()
	{
		//_audioSource.PlayOneShot(_deathClip);

		Destroy(this.gameObject);
	}

	protected abstract void OnCollisionEnter(Collision col);
}
