using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflection : MonoBehaviour
{
    public bool _collision;
    public float _bounceNum;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
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
    }
}