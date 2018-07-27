using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float VELOCIDADE = 10;
	public LayerMask FLOOR_MASK;
	public GameObject GAME_OVER_SCREEN;
	Vector3 MOVIMENTO;
	public bool IS_ALIVE = true;

	// Update is called once per frame
	void Update () {

		float axisX = Input.GetAxis( "Horizontal" );
		float axisZ = Input.GetAxis( "Vertical" );

		MOVIMENTO = velocidadePassos(axisX, 0, axisZ);

		animation(MOVIMENTO);

		restartGame();

	}

	private Vector3 velocidadePassos(float axisX, float axisY, float axisZ) {
		Vector3 vetor = new Vector3 (axisX, axisY, axisZ);
		return  vetor * VELOCIDADE * Time.deltaTime;
	}

	private void animation(Vector3 vetor) {

		Animator anima = GetComponent<Animator>();
		if (vetor != Vector3.zero) {
			anima.SetBool( "Movendo", true );
		} else {
			anima.SetBool( "Movendo", false );
		}

	}

	void FixedUpdate() {
		
		GetComponent<Rigidbody>().MovePosition( GetComponent<Rigidbody>().position + MOVIMENTO );

		// Cria uma linha que vai da "Main Camera" até a posição do mouse
		Ray linha = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit impact;
		// Cria um ponto onde a linha toca o chão,
		// máscara usada para o raio não tocar em nenhum outro objeto que não seja o chão
		if (Physics.Raycast (linha, out impact, 100, FLOOR_MASK)) {
			
			// Cria uma direção baseada no "impact" e no jogador (Cancela a posição Y para evitar rotação em altura);
			Vector3 PlayerRotation = impact.point - transform.position;
			PlayerRotation.y = transform.position.y;
			
			// Faz o "RigidBody" rotacionar o jogador para o "PlayerRotation"
			// Quaternion calcula quantos graus são necessários para rotacionar o jogador para a posição passada,
			// nesse caso "PlayerRotation"
			GetComponent<Rigidbody>().MoveRotation( Quaternion.LookRotation(PlayerRotation) );

		}

	}

	void restartGame() {

		if ( !IS_ALIVE && Input.GetButtonDown ("Fire1") ) {
			SceneManager.LoadScene("Game");
			Time.timeScale = 1;
		}

	}

}