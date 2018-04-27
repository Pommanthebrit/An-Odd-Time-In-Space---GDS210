using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile {

	[Header("Movement")]
	[SerializeField] private float _speed;

	[Header("Effects")]
	[SerializeField] private GameObject deathPT;

	protected override void Start ()
	{
		base.Start ();
		Move();
	}

	protected override void Move()
	{
		_rb.velocity = transform.forward * _speed;
	}

	protected override void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag != "Sword" && col.gameObject != _source)
		{
			Instantiate (deathPT, GetComponent<Collider>().transform.position, Quaternion.identity);
			Die();
		}
	}
}