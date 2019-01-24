using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public GameObject playerDie;
	public float maxHealth = 100f, currentHealth;
	public Image healthBar;
	public Text scoreUI;

	private int score = 0;

	private void Start(){
		currentHealth = maxHealth;
	}

	private void Die(){
		gameObject.SetActive (false);
		GameObject o = Instantiate (playerDie, transform.position, Quaternion.identity);
		Destroy (o, 3f);
	}

	public void TakeDamage(float amount){
		currentHealth -= amount;
		healthBar.fillAmount = currentHealth / maxHealth;
		if (currentHealth <= 0)
			Die ();
	}

	public void IncreaseScore(int point){
		score += point;
		scoreUI.text = score.ToString ();
	}

}
