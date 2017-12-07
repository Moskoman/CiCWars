using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

	public int life, speed;
	protected bool alive, canDash;
	public Vector2 moveDirection;
	public Vector2 shootDirection;
	public Vector2 dashDirection;
	public Rigidbody2D myRigidBody;
	public Gun currentGun;

	//Move
	protected void Move (Vector2 moveVector, Rigidbody2D moveRigidBody) {
		moveVector = getInputJoyLeft (moveVector);
		moveRigidBody.velocity = moveVector * speed;

	}

	//Shoot
	protected void Shoot () {
		if (Input.GetButton("RB")){
			shootDirection = getInputJoyRight (shootDirection);
			currentGun.Shoot(shootDirection);
		}
	}

	//Dash
	protected void Dash () {
		if (Input.GetAxisRaw ("Triggers") < 0.0f && canDash) {
			dashDirection = getInputJoyLeft (dashDirection);
			myRigidBody.AddForce ((dashDirection * 10), ForceMode2D.Impulse );

		}
	}

	//Super
	protected virtual void Super () {}

	//Super Input
	protected void SuperInput () {
		if (Input.GetButtonDown ("LB")){
			Super();
		}
	}

	protected Vector2 getInputJoyRight (Vector2 targetVector){
		targetVector.x = Input.GetAxisRaw ("R_Horizontal");
		targetVector.y = Input.GetAxisRaw ("R_Vertical");

		return targetVector;
	}

	Vector2 getInputJoyLeft (Vector2 targetVector){
		targetVector.x = Input.GetAxisRaw ("L_Horizontal");
		targetVector.y = Input.GetAxisRaw ("L_Vertical");

		return targetVector;
	}



	//Die
	protected bool Die () {
		if (life <= 0) {
			alive = false;
			speed = 0;
		}
		return alive;
	}


	//Collision Handling

}