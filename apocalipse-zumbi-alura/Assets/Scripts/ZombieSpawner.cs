using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

	public GameObject PREFAB;
	public float ZombieSpawnFrequencie = 2;
	float COUNTER = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		COUNTER += Time.deltaTime;

		if (COUNTER >= ZombieSpawnFrequencie) {
			Instantiate(PREFAB, transform.position, transform.rotation);
			COUNTER = 0;
		}
		
	}
	
}
