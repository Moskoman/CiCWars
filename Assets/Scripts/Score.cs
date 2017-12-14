using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    static GameObject _instance;

    public static Score instance {
        get {
            if (_instance == null) {
                _instance = Instantiate(Resources.Load("Score") as GameObject);
                DontDestroyOnLoad(_instance);
            }
            return _instance.GetComponent<Score>();
        }
    }

    public int[] scores;
}
