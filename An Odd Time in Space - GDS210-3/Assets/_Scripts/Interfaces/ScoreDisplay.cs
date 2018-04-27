using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	GameGod _Gg;
	Text scoreHUD;

	void Start () {
		_Gg = FindObjectOfType<GameGod> ();
		scoreHUD = GetComponent<Text> ();
	}
	
	void Update () {
		scoreHUD.GetComponent<Text> ().text = _Gg._score.ToString ();
	}
}