using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Transform player;

	private void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	private void Update(){
		if (player != null) {
			Vector3 playerPos = player.transform.position;
			transform.position = Vector3.MoveTowards (transform.position, playerPos, 2f * Time.deltaTime);
		}
	}

	private void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			player.GetComponent<Player> ().TakeDamage (10);
			Destroy (gameObject);
		}
	}
}
