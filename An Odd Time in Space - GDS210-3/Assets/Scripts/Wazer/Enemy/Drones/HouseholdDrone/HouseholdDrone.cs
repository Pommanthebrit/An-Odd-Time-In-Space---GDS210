using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseholdDrone : DroneController
{
	// TODO: Comment this script.
	[SerializeField] private float _slowStartPercentage;

	private float _beginSpeed;
	private float _smoothTime;

	private bool _increasingSpeed;
	private bool _decreasingSpeed;
	private bool _starting = true;

	protected override void Start()
	{
		base.Start();

		_beginSpeed = _speed;
		_speed = 0;
	}

	protected override void CalculateMovement()
	{
		float timeTillShot = _shootingMechanism._shootReadyTime - _shootingMechanism._currentTime;
		float timePassedFromShot = _shootingMechanism._shootDelay - timeTillShot;
		float timePassedSlow;
		float timeTillSlow;
		float smoothTime = _shootingMechanism._shootDelay * _slowStartPercentage;

		if(timeTillShot < _shootingMechanism._shootDelay * _slowStartPercentage && !_starting)
		{
			if(!_decreasingSpeed)
			{
				StartCoroutine(DecreaseSpeed());
				_decreasingSpeed = true;
			}
		}
		else if(_speed == 0 && !_decreasingSpeed)
		{
			if(_starting)
				_starting = false;
			
			if(!_increasingSpeed)
			{
				StartCoroutine(IncreaseSpeed());
				_increasingSpeed = true;
			}
		}
		base.CalculateMovement();


	}

	IEnumerator DecreaseSpeed()
	{
		float smoothTime = 0;

		while(_speed > 0)
		{
			smoothTime += Time.deltaTime / (_shootingMechanism._shootDelay * _slowStartPercentage);
			_speed = Mathf.Lerp(_beginSpeed, 0, smoothTime);

			yield return null;
		}

		_decreasingSpeed = false;
		yield break;
	}

	IEnumerator IncreaseSpeed()
	{
		float smoothTime = 0;

		while(_speed < _beginSpeed)
		{
			smoothTime += Time.deltaTime / (_shootingMechanism._shootDelay * _slowStartPercentage);
			_speed = Mathf.Lerp(0, _beginSpeed, smoothTime);
            
			yield return null;
		}

		_increasingSpeed = false;
		yield break;
	}
}
