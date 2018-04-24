using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HubRobotController : MonoBehaviour {

	public Transform player;
	Animator myRobotAnim;
	public float speed;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		myRobotAnim = GetComponent <Animator> ();
		agent = transform.parent.GetComponent<NavMeshAgent>();
		agent.destination = player.position;
		Walk ();
	}
	
	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 0.5) {
			Idle ();
		}
	}

	//function for walking animation
	public void Walk() {
		myRobotAnim.SetBool ("IsWalking", true);
		//agent.speed = speed;

	}

	//function for idle pose
	public void Idle() {
		myRobotAnim.SetBool ("IsWalking", false);
		//agent.speed = 0;
	}

}
