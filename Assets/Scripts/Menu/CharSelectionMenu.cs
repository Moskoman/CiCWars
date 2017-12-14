using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelectionMenu : MonoBehaviour {

    static public CharSelectionMenu instance { get; private set; }

    public string gameScene;
    public int maxPlayers = 2;
    public int[] sources;
    public int currentPlayer = 1;
    public int[] selections;

    void Awake() {
        if (instance)
            Debug.LogError("Multiple instances of CharSelection");
        instance = this;
        sources = new int[maxPlayers];
        selections = new int[maxPlayers];
        for (int i = 0; i < maxPlayers; ++i) {
            sources[i] = (int)PlayerPrefs.GetInt("Player" + (i+1).ToString() + "InputSource");
            selections[i] = -1;
        }
    }

    void Update() {
        if (currentPlayer < maxPlayers) {
            for (int i = 0; i < 5; ++i) {
                if (InputManager.ShootButton((InputSource)i)) {
                    bool alreadyUsed = false;
                    for (int k = 0; k < currentPlayer; ++k) {
                        if (sources[k] == i)
                            alreadyUsed = true;
                    }
                    if (!alreadyUsed) {
                        sources[currentPlayer] = i;
                        currentPlayer++;
                        break;
                    }
                }
            }
        }
    }

    public void StartGame() {
        PlayerPrefs.SetInt("PlayerAmount", currentPlayer);
        for (int i = 0; i < currentPlayer; ++i) {
            PlayerPrefs.SetInt("Player" + (i+1).ToString() + "InputSource", sources[i]);
            PlayerPrefs.SetInt("Player" + (i+1).ToString() + "Char", selections[i]);
        }
        Score.instance.scores = new int[currentPlayer];
        SceneManager.LoadScene(gameScene);
    }
}
