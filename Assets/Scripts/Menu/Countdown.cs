using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public bool countingDown = false;
    public float time = 10f;
    public Text text;


    void Update() {
        CheckIfAllSelected();
        UpdateCountdown();
    }

    void CheckIfAllSelected() {
        bool allSelected = true;
        for (int i = 0; i < CharSelectionMenu.instance.currentPlayer; ++i) {
            if (CharSelectionMenu.instance.selections[i] == -1)
                allSelected = false;
        }
        countingDown = allSelected;
    }

    void UpdateCountdown() {
        if (countingDown) {
            time -= Time.deltaTime;
            text.text = (Mathf.Ceil(time)).ToString();
            if (time < 0f)
                CharSelectionMenu.instance.StartGame();
        }
        else {
            text.text = "-";
            time = 10f;
        }
    }
}
