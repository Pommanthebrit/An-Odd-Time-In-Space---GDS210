using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : BaseEnemyController 
{
	protected override void Die()
	{
        RangeScoring.AddScore(_scoreWorth);
	}
}
