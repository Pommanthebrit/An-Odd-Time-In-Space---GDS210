using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	PlayerController _pC;

	public int myPlayerHealth;
	SpriteRenderer _spriteRenderer;
	public Sprite heartFull, heartEmpty;


	void Start () {
		_pC = FindObjectOfType<PlayerController> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	void Update () {
		if (myPlayerHealth == _pC._health) {
			_spriteRenderer.sprite = heartFull;
		} else
			_spriteRenderer.sprite = heartEmpty;
	}
}