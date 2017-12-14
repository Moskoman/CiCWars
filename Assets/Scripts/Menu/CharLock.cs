using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharLock : MonoBehaviour {

    public int charId;
    public Image img;
    public bool locked;
    public bool selected;

    void Update() {
        for (int i = 0; i < CharSelectionMenu.instance.maxPlayers; ++i) {
            if (CharSelectionMenu.instance.selections[i] == charId) {
                locked = true;
                break;
            }
            else
                locked = false;
        }

        if (charId >= 3)
            locked = true;

        if (locked)
            img.color = Color.black;
        else
            img.color = Color.white;
        if (selected)
            img.color = Color.white;
    }
}
