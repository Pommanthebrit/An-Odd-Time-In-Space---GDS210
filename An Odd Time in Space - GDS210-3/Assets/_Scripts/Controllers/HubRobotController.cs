using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HubRobotController : MonoBehaviour {

	[SerializeField] private AudioClip[] robot_Talk;
	private AudioSource _audioSource;
	public Transform waypoint; //waypoint for robot to walk towards
	Animator myRobotAnim;
	NavMeshAgent agent;

	void Start () {
		_audioSource = GetComponent<AudioSource>();
		myRobotAnim = GetComponent <Animator> ();
		agent = GetComponent<NavMeshAgent>();
		agent.destination = waypoint.position; //sets Robot destination to waypoint
		StartCoroutine("Walk");
	}
	
	void Update () { 
		if (agent.remainingDistance < 0.5) { //stops robot within 0.5m of waypoint
			Idle ();
			agent.GetComponent<NavMeshAgent> ().enabled = false;
			this.enabled = false; //Chris-disable this script after run its course
		}
	}

	public IEnumerator Walk() { //function for walking animation
		myRobotAnim.SetBool ("IsWalking", true); //plays walk animation
		_audioSource.Play(); //plays walking audio
		yield return new WaitForSeconds(3.5f); //waits duration of walk distance before stopping looping walk audio
		_audioSource.Stop ();
		_audioSource.PlayOneShot (robot_Talk [Random.Range(0, robot_Talk.Length)]); //Chris- modified to play as array rather than if statement
	}

	public void Idle() { //function for idle pose
		myRobotAnim.SetBool ("IsWalking", false); 
	}

}
