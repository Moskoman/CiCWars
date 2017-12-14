using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

	public Text maxHP, currentHP, currentAmmo, maxAmmo;

	public void updateHP (int newHP) {

		currentHP.text = "" + newHP;
		Debug.Log (currentHP.text);

	}

	public void updateAmmo (int newAmmo) {
	
		currentAmmo.text = "" + newAmmo;

	}

}
