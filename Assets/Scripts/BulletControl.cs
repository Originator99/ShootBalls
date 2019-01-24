using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BulletControl : MonoBehaviour {
	public GameObject explosion;
	private Transform player;

	public void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;	
	}

	private void Update(){
		if (CheckBounds ())
			Destroy (gameObject);
	}

	private bool CheckBounds(){
		float vertEx = Camera.main.orthographicSize;
		float horzEx = Camera.main.aspect * Camera.main.orthographicSize;
		if (transform.position.x > -horzEx && transform.position.x < horzEx && transform.position.y > -vertEx && transform.position.y < vertEx)
			return false;
		return true;
	}

	private void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Enemy") {
			Destroy (col.gameObject);
			player.GetComponent<Player> ().IncreaseScore (1);
			Explode ();
			Destroy (gameObject);
		}
	}

	private void Explode(){
		CameraShaker.Instance.ShakeOnce (4f, 4f, 0.1f, 1f);
		GameObject temp = Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (temp, 2f);
	}
}
