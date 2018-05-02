using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Projectile {

    [Header("Movement")]
    [SerializeField] private float _speed;

    [Header("Effects")]
    [SerializeField] private GameObject deathPT;

    [Header("Other Audio")]
    [SerializeField] private AudioClip _hitGroundSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Die();
        }
    }

    protected override void Start()
    {
        base.Start();
        Move();
    }

    protected override void Move()
    {
        _rb.velocity = transform.forward * _speed;
    }

    protected override void OnCollisionEnter(Collision col)
    {
        //_audioSource.PlayOneShot(_hitGroundSound);
    }

    protected override void Die()
    {
        Instantiate(deathPT, GetComponent<Collider>().transform.position, Quaternion.identity);
        base.Die();
    }
}
