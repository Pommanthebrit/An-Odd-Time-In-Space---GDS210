using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflection : MonoBehaviour {

	AudioSource _audioSource;

	[Header("Effects")]
	[SerializeField] GameObject deflectPT;
	[SerializeField] AudioClip[] swordDeflects;

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

    void OnCollisionEnter(Collision collider) {
			Debug.Log ("Sword hit: " + collider);
			Instantiate (deflectPT, collider.transform.position, Quaternion.identity);
			_audioSource.PlayOneShot (swordDeflects [Random.Range (0, swordDeflects.Length)]); 
    }
}

/* Unused deflecting script, instead functions using physics
 
 	public bool _collision;
    public float _bounceNum;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
        ContactPoint contact;
        if(_bounceNum > 0 && collision.gameObject.layer != 8)
        {
            contact = collision.contacts[0];
            float dot = Vector3.Dot(contact.normal, -transform.forward);
            dot *= 2;

            Vector3 reflection = contact.normal * dot;
            reflection = reflection + transform.forward;

            _rb.velocity = _rb.transform.TransformDirection(reflection.normalized * 15.0f);
            _bounceNum -= 1;
        }
        */