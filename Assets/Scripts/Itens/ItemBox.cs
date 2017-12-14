using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {

	public List <Item> Itens = new List <Item> ();

	// Use this for initialization
	void Start () {
		Itens.Add (new AmmoBox ());
		Itens.Add (new HealthBox ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collisionInfo) {

		if (collisionInfo.gameObject.tag == "Player") {
			int random = Random.Range (0, 2);
			Debug.Log (random);
			Itens [random].ApplyEffect(collisionInfo.gameObject);
			Destroy (gameObject);
		}
	}

}
