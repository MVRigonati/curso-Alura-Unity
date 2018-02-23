using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject JOGADOR;
	Vector3 DISTANCIA_CAM_JOGADOR;

	// Use this for initialization
	void Start () {
		
		transform.position = JOGADOR.transform.position + new Vector3( -1, 16, -8 );
		transform.rotation = new Quaternion( -0.5f, 0, 0, -0.9f );
		DISTANCIA_CAM_JOGADOR = transform.position - JOGADOR.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = JOGADOR.transform.position + DISTANCIA_CAM_JOGADOR;
	}

}
