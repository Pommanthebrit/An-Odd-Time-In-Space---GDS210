using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	PlayerController _playerCtrl;

	public int myPlayerHealth;
	Image _image;
	public Sprite heartFull, heartEmpty;


	void Start () {
		_playerCtrl = FindObjectOfType<PlayerController> ();
		_image = GetComponent<Image> ();
	}
	
	void Update () {
		if (_playerCtrl._health >= myPlayerHealth) {
			_image.sprite = heartFull;
		} else
			_image.sprite = heartEmpty;
	}
}