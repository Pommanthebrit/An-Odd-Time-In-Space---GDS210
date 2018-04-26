using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int _health;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            _health--;

            if(_health < 1)
            {
                GameObject.FindGameObjectWithTag("GameGod").GetComponent<WazerStartup>().EndWazeGame();
                _health = 3;
            }
        }
    }
}
