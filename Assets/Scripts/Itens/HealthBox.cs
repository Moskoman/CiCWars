using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : Item {

	public int bonusLife = 30;

	public override void ApplyEffect (GameObject Player) {

		Player myPlayer = Player.GetComponent<Player> ();
		if (myPlayer.life + bonusLife >= myPlayer.maxLife) {
			myPlayer.life = myPlayer.maxLife;
		}
		else 
			myPlayer.life += bonusLife;
			
	}

}
