using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Item {

	public int bonusAmmo;

	protected void ApplyEffect (GameObject player) {
	
		Gun myGun = player.GetComponent<Player> ().currentGun;
		bonusAmmo = Random.Range (10, 50);
		myGun.currentAmmo += bonusAmmo; 
	}

}
