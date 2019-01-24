using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
	[SerializeField]private float speed = 5f;
	[SerializeField]private float rotationSpeed = 1.0f;


	private void Update () {
		Movement ();
		Rotation ();
	}

	private void Movement(){
		//float horz = Input.GetAxisRaw ("Horizontal");
		//float ver = Input.GetAxisRaw ("Vertical");
		//transform.Translate (new Vector2 (horz, ver) * speed * Time.deltaTime);

		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}
	private void Rotation(){
		Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		SetCrosshairPos (mouseScreenPosition);
		Vector3 lookAt = mouseScreenPosition;
		float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}
	private void SetCrosshairPos(Vector3 pos){
		pos.z = 0;
		transform.GetChild (0).transform.position = Vector3.Lerp (transform.GetChild (0).transform.position, pos, 15f * Time.deltaTime);
	}
}
