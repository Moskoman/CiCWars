using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

	private int speed = 10;
	public int damage = 15;
	private Player hitedPlayer;
	private Rigidbody2D bulletRigdyBody;
	public Vector2 bulletDirection;
	public int shooterId;


	// Use this for initialization
	void Start () {
		hitedPlayer = null;
		Move ();
	}

	// Update is called once per frame
	void Update () {

	}

	void Move () {
		bulletRigdyBody = GetComponent<Rigidbody2D>();
		bulletRigdyBody.velocity = bulletDirection * speed;
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Player") {
			hitedPlayer = other.gameObject.GetComponent<Player> ();
			if (hitedPlayer.id != shooterId) {
				hitedPlayer.life -= damage;
				hitedPlayer.healthBar.fillAmount = ((float)hitedPlayer.life / (float)hitedPlayer.maxLife);
				Destroy (gameObject);
			}
		}
		if (other.gameObject.layer == 10)
			Destroy(gameObject);
	}

}
