using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int _health;
    [HideInInspector] public RaycastHit _hitInfo;

    [Header("Deflection Aiming")]
    [SerializeField] private float _maxDisForRay;
    [SerializeField] private LayerMask _layersToCount;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            _health--;

            if(_health < 1)
            {
                GameObject.FindGameObjectWithTag("GameGod").GetComponent<WazerStartup>().EndWazeGame();
            }
        }
    }

    public void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hitInfo, _maxDisForRay, _layersToCount))
        {
            Debug.Log(_hitInfo.collider.name);
        }
        else
        {
        }
    }
}
