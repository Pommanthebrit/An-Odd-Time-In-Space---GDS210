using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    [SerializeField] private float _hitForce;
    [SerializeField] private float _pushRadius;
	[SerializeField] GameObject _clubHead, _ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
			other.attachedRigidbody.AddExplosionForce (_hitForce, _clubHead.transform.position, _pushRadius, 0f, ForceMode.Impulse);
			other.attachedRigidbody.AddTorque (Vector3.forward, ForceMode.Impulse);
            Debug.Log(other);
        }
    }
}