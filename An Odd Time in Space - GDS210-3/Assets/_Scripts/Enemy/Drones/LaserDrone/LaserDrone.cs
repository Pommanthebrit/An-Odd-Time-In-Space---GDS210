using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LaserDrone uncomplete.
public class LaserDrone : DroneController 
{
	#region "Extra Movement Variables"
	[Header("Extra Movement")]

	[SerializeField] private bool _verticalMove;

	[Tooltip("Increases the speed of acceleration. The lower the value the faster the acceleration.")]
	[SerializeField] private float _smoothTime;

	[Tooltip("The max velocity this LaserDrone will ever reach.")]
	[SerializeField] private float _maxVerticalVelocity;

	[Tooltip("This will ensure turnpoint is unreachable. Makes turnpoint less then the max velocity by the amount specificied here.")]
	[SerializeField] private float _accuracyMeasure;

	private int _vertDir;
	#endregion

	// Initialse.
	protected override void Start ()
	{
		base.Start (); // Inherit base Start actions.

		// Randomises start direction.
		if(Random.value < 0.5)
			_vertDir = -1;
		else
			_vertDir = 1;
	}

	// Calculates movement for LaserDrone.
	protected override void CalculateMovement()
	{
		// Adds base movement.
		base.CalculateMovement();

		// Moves vertical if applicable.
		if(_verticalMove)
		{
			// Smoothly increases velocity over "_verticalMove" given time.
			float currentDampVel = 0; // SmmothDamp float placeholder for mandatory output ref.
			_velToAdd += new Vector3 (0, Mathf.SmoothDamp(_rb.velocity.y, _vertDir * _maxVerticalVelocity, ref currentDampVel, _smoothTime), 0);
		}

		// Swithces vertical move direction if max velocity - accuracy measure is reached.
		if (_maxVerticalVelocity - 1f < Mathf.Abs(_velToAdd.y))
			_vertDir = _vertDir * -1;
	}
}
