using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {

    static public PlayerSpawner instance { get; private set; }

    public List<GameObject> charPrefabs = new List<GameObject>();
    public Vector2[] spawnPoints = new Vector2[4];
    public int playerAmount;
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> healthBarCanvas = new List<GameObject>();

    void Awake() {
        if (instance)
            Debug.LogError("Multiple instances of PlayerSpawner");
        instance = this;
        GeneratePlayers();
    }

    void GeneratePlayers() {
        playerAmount = PlayerPrefs.GetInt("PlayerAmount");
        for (int i = 0; i < playerAmount; ++i) {
            players.Add(Instantiate(charPrefabs[PlayerPrefs.GetInt("Player" + (i+1).ToString() + "Char")]));
            players[i].GetComponent<Player>().inputSource =
                (InputSource)PlayerPrefs.GetInt("Player" + (i+1).ToString() + "InputSource");
            players[i].transform.position = spawnPoints[i];
            players[i].GetComponent<Player>().healthBar = healthBarCanvas[i].transform.GetChild(2).GetComponent<Image>();
        }
        for (int i = playerAmount; i < 4; ++i)
            healthBarCanvas[i].GetComponent<CanvasGroup>().alpha = 0;
    }

    void OnDrawGizmosSelected() {
        for (int i = 0; i < spawnPoints.Length; i++) {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(spawnPoints[i] + Vector2.down/4, spawnPoints[i] + Vector2.up/4);
            Gizmos.DrawLine(spawnPoints[i] + Vector2.left/4, spawnPoints[i] + Vector2.right/4);
        }
    }
}
