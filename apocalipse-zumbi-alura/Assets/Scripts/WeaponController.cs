using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject FIRE;
	public GameObject FIRE_POSITION;

	// Update is called once per frame
	void Update () {

		if ( Input.GetButtonDown("Fire1") ) {
			Instantiate(FIRE, FIRE_POSITION.transform.position, FIRE_POSITION.transform.rotation);
		}

	}

}