using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public string charSelectionMenu;

    bool requestedStart = false;

    void Start() {
        for (int i = 0; i < 5; ++i) {
            PlayerPrefs.SetInt("Player" + (i+1).ToString() + "InputSource", -1);
        }
    }

    void Update() {
        if (!requestedStart) {
            for (int i = 0; i < 5; ++i) {
                if (InputManager.ShootButton((InputSource)i)) {
                    PlayerPrefs.SetInt("Player1InputSource", i);
                    requestedStart = true;
                    SceneManager.LoadScene(charSelectionMenu);
                    break;
                }
            }
        }
    }
}
