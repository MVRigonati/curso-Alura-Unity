using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public float VELOCIDADE = 10;
	public int LIFE_TIME = 5;

	void Start() {
		Destroy(this.gameObject, LIFE_TIME);
	}

	void FixedUpdate() {
		GetComponent<Rigidbody>().MovePosition( GetComponent<Rigidbody>().position + transform.forward * VELOCIDADE * Time.deltaTime );
	}

	void OnTriggerEnter(Collider otherObject) {

		if (otherObject.tag == "Inimigo") {
			Destroy(otherObject.gameObject);
		}

		Destroy (this.gameObject);

	}

}