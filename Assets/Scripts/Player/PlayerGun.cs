using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {
	[SerializeField] private Transform nozzelPos;
	[SerializeField] private GameObject bulletPrefab;
	public float shootDelay = 2f, timestamp;
	public Camera mainCam;

	private void Update(){
		if (Time.time>=timestamp && Input.GetMouseButtonDown(0)) {
			Shoot ();
			timestamp = Time.time + shootDelay;
		}
	}

	private void Shoot(){
		GameObject g = Instantiate (bulletPrefab, nozzelPos.position, Quaternion.identity);
		g.GetComponent<Rigidbody2D> ().velocity = transform.right * 30f;
	}

}
