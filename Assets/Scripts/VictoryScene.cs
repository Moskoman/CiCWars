using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour {

    public GameObject[] chars = new GameObject[3];
    public Text text;

    void Start() {
        int victorPlayer = PlayerPrefs.GetInt("VictorPlayer");
        int victorChar = PlayerPrefs.GetInt("VictorChar");
        text.text = "Player " + (victorPlayer+1).ToString() + " wins!";
        chars[victorChar].SetActive(true);
        Invoke("BackToStartMenu", 5f);
    }

    void BackToStartMenu() {
        SceneManager.LoadScene("Start Menu");
    }
}
