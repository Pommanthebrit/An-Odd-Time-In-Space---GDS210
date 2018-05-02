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
    [SerializeField] private Deflection _playerDeflectionItem;
    [HideInInspector] public Transform _selectedTransform;

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
            _selectedTransform = _hitInfo.collider.transform;

            if(_selectedTransform.GetComponent<DroneController>().Targeted != true)
                _selectedTransform.GetComponent<DroneController>().Targeted = true;

            _playerDeflectionItem._targetedEnemy = _selectedTransform;
            Debug.Log("Looking At: " + _hitInfo.collider.name);
        }
        else
        {
            if(_selectedTransform != null && _selectedTransform.GetComponent<DroneController>().Targeted != false)
                _selectedTransform.GetComponent<DroneController>().Targeted = false;
        }
    }
}
