using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LaserDrone uncomplete.
public class LaserDrone : DroneController 
{
	[Header("Extra Movement")]
	[SerializeField] private bool _verticalMove;
	[SerializeField] private float _verticalForce;
	[SerializeField] private float _maxVerticalVelocity;
	private int _vertDir;

	protected override void Start ()
	{
		base.Start ();

		// Randomises start direction.
		if(Random.value < 0.5)
		{
			_vertDir = -1;
		}
		else
		{
			_vertDir = 1;
		}
	}

	// Calculates movement for LaserDrone.
	protected override void CalculateMovement()
	{
		base.CalculateMovement();

		if(_verticalMove)
		{
			float currentVertVel = 0;
			_velToAdd += new Vector3 (0, Mathf.SmoothDamp(_rb.velocity.y, _vertDir * _maxVerticalVelocity, ref currentVertVel, _verticalForce), 0);
			print (currentVertVel);
		}

		if (_maxVerticalVelocity - 1f < Mathf.Abs(_velToAdd.y))
		{
//			_rb.velocity = _rb.velocity + new Vector3 (0, _rb.velocity.x - _vertDir * 0.1f, 0);
//			_vertDir = _vertDir * -1;

			_vertDir = _vertDir * -1;
//			_rb.velocity = Vector3.zero;
			print("test");
		}
	}
}
