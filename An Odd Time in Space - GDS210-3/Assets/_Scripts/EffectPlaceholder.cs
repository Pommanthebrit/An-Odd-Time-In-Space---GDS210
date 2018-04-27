using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlaceholder : MonoBehaviour {

	[SerializeField] private float _lifeDuration;

	void Start() 
	{
		Invoke("Destroy", _lifeDuration);
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}
}
