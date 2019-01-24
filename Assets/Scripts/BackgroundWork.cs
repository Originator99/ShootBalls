using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWork : MonoBehaviour {
	public GameObject enemyPrefab;
	public GameObject player;

	[SerializeField]private float SpawnTime = 1f;

	private void Start(){
		InvokeRepeating ("SpawnEnemy", 0.3f, SpawnTime);
	}

	private void SpawnEnemy(){
		if (player.activeSelf) {
			Vector2 pos = GenerateSpawnPoint ();
			Instantiate (enemyPrefab, pos, Quaternion.identity);
		}
	}

	private Vector2 GenerateSpawnPoint(){
		float vertEx = Camera.main.orthographicSize;
		float horzEx = Camera.main.aspect * Camera.main.orthographicSize;
		float x = Random.Range (-horzEx, horzEx);
		float y = Random.Range (-vertEx, vertEx);
		return new Vector2 (x, y);
	}
}