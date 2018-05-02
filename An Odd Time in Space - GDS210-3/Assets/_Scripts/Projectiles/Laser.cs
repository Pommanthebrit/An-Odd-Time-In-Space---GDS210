using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{

    [Header("Movement")]
    [SerializeField] private float _speed;

    [Header("Deflection")]
    [SerializeField] private float _maxDeflectAimDis;
    [SerializeField] private LayerMask _layersToDetect;

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
            StartCoroutine(Deflect());
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
            StartCoroutine(Deflect());
    }

    IEnumerator Deflect()
    {
        yield return new WaitForFixedUpdate();

        RaycastHit hitInfo;
        Ray screenCenter = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(screenCenter, out hitInfo, 100.0f, _layersToDetect))
        {
            transform.LookAt(hitInfo.point);
            Move();
            //Debug.Log(hitInfo.rigidbody.name);
            Debug.Log("Test");
        }

        yield return null;
    }
}