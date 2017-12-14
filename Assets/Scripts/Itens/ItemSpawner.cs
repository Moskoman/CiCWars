using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public GameObject itemBox;
	public int luckySpawn;
	// Use this for initialization
	void Start () {


			Invoke ("SpawnBox", 4f);

	}
	
	// Update is called once per frame
	void Update () {

			luckySpawn = Random.Range (0, 1000);
	}

	protected void SpawnBox () {
		if (luckySpawn >= 900) {
			Transform spawnPosition = transform;
			if (GameObject.FindGameObjectWithTag ("ItemBox") == null) {
				spawnPosition.position = new Vector3 (Random.Range (-8.56f, 8.20f), Random.Range (-4.5f, 3.25f), 0);
				Instantiate (itemBox, spawnPosition);
			}

		}
			Invoke ("SpawnBox", 10f);
		
	}
}
