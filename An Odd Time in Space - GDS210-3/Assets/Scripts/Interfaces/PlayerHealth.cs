using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int myPlayerHealth;
	SpriteRenderer _spriteRenderer;
	public Sprite heartFull, heartEmpty;


	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	void Update () {
		if (myPlayerHealth == 0) {
			_spriteRenderer.sprite = heartFull;
		} else
			_spriteRenderer.sprite = heartEmpty;
	}
}