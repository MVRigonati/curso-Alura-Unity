using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float VELOCIDADE;
	private GameObject JOGADOR;

	void Start() {
		
		// Encontrando jogador pela tag
		JOGADOR = GameObject.FindWithTag("Jogador");

		// Escolhendo e ativando uma das skins do zumbi
		int ZombieType = Random.Range(1, 28);
		transform.GetChild(ZombieType).gameObject.SetActive(true);

	}

	void FixedUpdate() {

		float distance = Vector3.Distance( transform.position, JOGADOR.transform.position );

		Vector3 direction = JOGADOR.transform.position - transform.position;
		RotateBody( direction );

		if (distance > ColisionDiameter () + 0.5) {
			enemyMove(direction);
		} else {
			enemyAttack();
		}

	}

	private void enemyMove(Vector3 direction) {
		GetComponent<Animator>().SetBool ("Atacar", false);
		GetComponent<Rigidbody>().MovePosition( GetComponent<Rigidbody>().position + WalkSpeed(direction) );
	}

	private void enemyAttack() {
		GetComponent<Animator>().SetBool ("Atacar", true);
	}

	private Vector3 WalkSpeed(Vector3 direction) {
		return direction.normalized * VELOCIDADE * Time.deltaTime;
	}

	private float ColisionDiameter() {
		return (GetComponent<CapsuleCollider>().radius * 2);
	}

	private void RotateBody(Vector3 direction) {
		GetComponent<Rigidbody>().MoveRotation( Quaternion.LookRotation(direction) );
	}

	void Ataque() {
		
		JOGADOR.GetComponent<PlayerController>().GAME_OVER_SCREEN.SetActive( true );
		JOGADOR.GetComponent<PlayerController>().IS_ALIVE = false;
		Time.timeScale = 0;

	}

}
