using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlowly : MonoBehaviour {

    [SerializeField] private float _rotateSpeed;

	void Start ()
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value) * _rotateSpeed, ForceMode.Impulse);
    }
}
