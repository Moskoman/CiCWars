using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameConditions : MonoBehaviour {

    void Update() {
        int livePlayers = 0;
        int index = -1;
        for (int i = 0; i < PlayerSpawner.instance.playerAmount; ++i) {
            if (PlayerSpawner.instance.players[i].GetComponent<Player>().life > 0) {
                livePlayers++;
                index = i;
            }
        }
        if (livePlayers == 1) {
            Debug.Log("Player " + (index+1) + " wins!");
        }
    }
}
