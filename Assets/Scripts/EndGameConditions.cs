using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameConditions : MonoBehaviour {

    public string victoryScene = "Start Menu";

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
            Score.instance.scores[index]++;
            if (Score.instance.scores[index] >= 3)
                SceneManager.LoadScene(victoryScene);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
