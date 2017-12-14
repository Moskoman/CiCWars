using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : Item {

	public int bonusLife = 30;
	protected void ApplyEffect (GameObject Player) {
	
		Player myPlayer = Player.GetComponent<Player> ();
		myPlayer.life += bonusLife;
			
	}

}
