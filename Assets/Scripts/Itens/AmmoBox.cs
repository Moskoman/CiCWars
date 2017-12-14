using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Item {

	public int bonusAmmo;

	public override void ApplyEffect (GameObject player) {

		Gun myGun = player.GetComponent<Player> ().currentGun;
		bonusAmmo = Random.Range (10, 50);
		if (myGun.currentAmmo + bonusAmmo >= myGun.maxAmmo) {
			myGun.currentAmmo = myGun.maxAmmo; 
		} else
			myGun.currentAmmo += bonusAmmo;
	}

}
