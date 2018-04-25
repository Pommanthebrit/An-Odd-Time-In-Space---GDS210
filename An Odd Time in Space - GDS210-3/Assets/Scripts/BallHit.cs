using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    [SerializeField] private float _hitForce;
    [SerializeField] private float _pushRadius;
    private Rigidbody _rb;
    private Collider _clubCol;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.attachedRigidbody.AddExplosionForce(_hitForce, transform.position, _pushRadius);
            Debug.Log(other);
        }
    }
}
