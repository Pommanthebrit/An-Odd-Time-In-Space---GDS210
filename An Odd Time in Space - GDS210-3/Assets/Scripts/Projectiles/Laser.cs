using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile {

	[Header("Movement")]
	[SerializeField] private float _speed;

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
		Debug.LogError("Collision");

		if(col.gameObject != _source)
		{
			Die();
		}
	}
}
