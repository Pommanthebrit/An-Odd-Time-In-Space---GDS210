using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlowly : MonoBehaviour {

    private float _rotateSpeed = 0f;

	void Start ()
    {
		_rotateSpeed = Random.Range (1f, 2f);
        GetComponent<Rigidbody>().AddTorque(new Vector3 (Random.value, Random.value, Random.value) * _rotateSpeed, ForceMode.Impulse);
    }
}
