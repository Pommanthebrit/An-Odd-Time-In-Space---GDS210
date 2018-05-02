using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{

    [Header("Movement")]
    [SerializeField] private float _speed;
    [HideInInspector] public Transform _homingTarget;

    [Header("Effects")]
    [SerializeField] private GameObject deathPT;

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
        if (col.gameObject.tag != "Sword")
        {
            Instantiate(deathPT, GetComponent<Collider>().transform.position, Quaternion.identity);
            Die();
        }
        else
        {
            if (_homingTarget == null)
                _rb.velocity *= -1;
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            gameObject.tag = "PlayerProjectile";
        }
    }

    private void HomeIn()
    {
        _rb.velocity = (transform.position - _homingTarget.position).normalized * _speed;
    }

    private void Update()
    {
        if (_homingTarget != null)
            HomeIn();
    }
}