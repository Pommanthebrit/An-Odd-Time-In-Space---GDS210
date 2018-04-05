using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseEnemyController : MonoBehaviour 
{
	[Header("Death")]
	[SerializeField] protected GameObject _enemyDeathEffect;
	[SerializeField] protected int _health;
	[SerializeField] protected int _scoreWorth;

	// Other Variables.
	protected Rigidbody _rb;

	protected virtual void Start()
	{
		_rb = this.gameObject.GetComponent<Rigidbody>();
	}

	// This function destroys this enemy and instantiates death effect.
	protected virtual void Die()
	{
		Instantiate(_enemyDeathEffect, transform.position, transform.rotation);
		// Add score.
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision otherCol)
	{
		if(otherCol.gameObject.tag == "PlayerProjectile")
		{
			TakeHealth();
		}
	}

	void TakeHealth()
	{
		_health--;

		if(_health < 1)
		{
			Die();
		}
	}
}
