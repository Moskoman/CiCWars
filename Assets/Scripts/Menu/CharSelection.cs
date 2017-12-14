using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelection : MonoBehaviour {

    public int maxPlayers = 2;
    public InputSource[] sources;
    public int currentPlayer = 1;

    void Start() {
        sources = new InputSource[maxPlayers];
        for (int i = 0; i < maxPlayers; ++i)
            sources[i] = (InputSource)PlayerPrefs.GetInt("Player" + (i+1).ToString() + "InputSource");
    }

    void Update() {
        if (currentPlayer < maxPlayers) {
            for (int i = 0; i < 5; ++i) {
                if (InputManager.ShootButton((InputSource)i)) {
                    bool alreadyUsed = false;
                    for (int k = 0; k < currentPlayer; ++k) {
                        if ((int)sources[k] == i)
                            alreadyUsed = true;
                    }
                    if (!alreadyUsed) {
                        sources[currentPlayer] = (InputSource) i;
                        currentPlayer++;
                        break;
                    }
                }
            }
        }
    }
}
