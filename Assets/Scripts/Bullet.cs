using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private int speed = 10;
	public int damage = 15;
	private Player hitedPlayer;
	private Rigidbody2D bulletRigdyBody;
	public Vector2 bulletDirection;

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

/*	void OnCollisionEnter2D (Collision2D collisionInfo){
		hitedPlayer = collisionInfo.gameObject.GetComponent<Player>();
		hitedPlayer.life -= 10;
		Destroy (this.gameObject, 2f);
	} */

}