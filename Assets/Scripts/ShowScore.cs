using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    void Update() {
        var playerAmount = PlayerSpawner.instance.playerAmount;
        var text = GetComponent<Text>();
        text.text = Score.instance.scores[0].ToString();
        for (int i = 1; i < playerAmount; ++i)
            text.text += (" | " + Score.instance.scores[i].ToString());
    }
}
