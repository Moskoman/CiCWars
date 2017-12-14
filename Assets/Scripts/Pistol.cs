using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {

	private int shineAnimationControler = 0;
	public Animator myAnimator;

	public Pistol () {
		Id = 0;
		maxAmmo = currentAmmo = 50;
		roundCapacity = ammoOnRound = 7;
		coolDownWeapon = 0.5f;
		reloadTime = 1f;
		fireRate = 0.5f;
		canShoot = true;

	}
	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		shineAnimationControler = Random.Range (0, 100);
		if (shineAnimationControler >= 80) {

			myAnimator.SetBool ("Can_shine", true);
		} else
			myAnimator.SetBool ("Can_shine", false);


	}

}
