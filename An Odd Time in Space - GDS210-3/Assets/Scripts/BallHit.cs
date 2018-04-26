using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    [SerializeField] private float _hitForce;
	[SerializeField] private float _torqueForce;
    [SerializeField] private float _pushRadius;

	private AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
			_audioSource.Play ();
            other.attachedRigidbody.AddExplosionForce(_hitForce, transform.position, _pushRadius);
			other.attachedRigidbody.AddTorque (Vector3.forward, ForceMode.Impulse);
            Debug.Log(other);
        }
    }
}