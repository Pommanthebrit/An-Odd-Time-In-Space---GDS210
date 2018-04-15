using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseEnemyController : MonoBehaviour 
{
	#region "Death Settings"
	[Header("Death")]

	[SerializeField] protected GameObject _enemyDeathEffect;

	[SerializeField] protected int _health;

	[Tooltip("How much score should be given upon this enemies death")]
	[SerializeField] protected int _scoreWorth;
	#endregion

	[Header("Other")]
	public GameGod _gg;
	protected Rigidbody _rb;

	protected virtual void Start()
	{
		_rb = this.gameObject.GetComponent<Rigidbody>();
	}

	// Destroys this enemy and instantiates death effect.
	protected virtual void Die()
	{
//		Instantiate(_enemyDeathEffect, transform.position, transform.rotation);
		// TODO: Create death effect.

		_gg.AddScore(_scoreWorth);
		_gg._currentEnemyCount--;

		this.gameObject.SetActive(false);
	}
		
	void OnCollisionEnter(Collision otherCol)
	{
		if(otherCol.gameObject.tag == "PlayerProjectile")
		{
			TakeHealth(1);
		}
	}

	void OnMouseDown()
	{
		TakeHealth(1);
	}

	// Takes away health.
	void TakeHealth(int damage)
	{
		_health -= damage;

		if(_health < 1)
		{
			Die();
		}
	}
}
