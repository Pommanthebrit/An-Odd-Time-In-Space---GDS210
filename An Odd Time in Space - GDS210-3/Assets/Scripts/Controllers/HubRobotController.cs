using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HubRobotController : MonoBehaviour {

	[SerializeField] private AudioClip Robot_Talk1;
	[SerializeField] private AudioClip Robot_Talk2;
	private AudioSource _audioSource;
	public Transform waypoint; //waypoint for robot to walk towards
	int voice; //variable for selecting random voice line
	Animator myRobotAnim;
	NavMeshAgent agent;

	void Start () {
		_audioSource = GetComponent<AudioSource>();
		myRobotAnim = GetComponent <Animator> ();
		agent = transform.parent.GetComponent<NavMeshAgent>();
		agent.destination = waypoint.position; //sets Robot destination to waypoint
		StartCoroutine("Walk");
	}
	
	void Update () { 
		if (agent.remainingDistance < 0.5) { //stops robot within 0.5m of waypoint
			Idle ();
		}
	}

	public IEnumerator Walk() { //function for walking animation
		myRobotAnim.SetBool ("IsWalking", true); //plays walk animation
		_audioSource.Play(); //plays walking audio
		yield return new WaitForSeconds(3.5f); //waits duration of walk distance before stopping looping walk audio
		_audioSource.Stop ();
		voice = Random.Range (1, 3); //random number between 1 and 2 for selecting robot talking sound effect
		print (voice);
		if (voice == 1) {
			_audioSource.PlayOneShot (Robot_Talk1); 
		} else {
			_audioSource.PlayOneShot (Robot_Talk2);
		}
	}

	public void Idle() { //function for idle pose
		myRobotAnim.SetBool ("IsWalking", false); 
	}

}
