using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {

	public Pistol () {
		Id = 0;
		maxAmmo = 10;
		coolDownWeapon = 0.5f;
		fireRate = 0.5f;
		canShoot = true;

	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
