using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HubRobotController : MonoBehaviour {

	public Transform player;
	Animator myRobotAnim;
	public float speed;

	// Use this for initialization
	void Start () {
		myRobotAnim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Walk ();
	}

	public void Walk() {
		myRobotAnim.SetBool ("IsWalking", true);
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.speed = speed;
		agent.destination = player.position;
	}

	public void Idle() {
		myRobotAnim.SetBool ("IsWalking", false);
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.speed = 0;
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.name == "Player") {
			Idle ();
		}
	}

}
