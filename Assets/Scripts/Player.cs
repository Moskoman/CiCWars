﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour {

	public InputSource inputSource;
	private Animator myAnimator;
	public int life, speed, id, maxLife;
	protected bool alive, canDash;
	public Vector2 moveDirection;
	public Vector2 shootDirection;
	public Vector2 dashDirection;
	public Rigidbody2D myRigidBody;
	public Gun currentGun;
	public Image healthBar;
	public Text bulletsText;

	//Move
	protected void Move (Vector2 moveVector, Rigidbody2D moveRigidBody) {
		myAnimator = GetComponent<Animator> ();
		moveVector = getInputJoyLeft ();
		moveRigidBody.velocity = moveVector * speed;
		if (alive == false || moveRigidBody.velocity == new Vector2 (0, 0)) {
			myAnimator.SetBool ("Moving", false);
		}
		else
			myAnimator.SetBool ("Moving", true);
		if (moveRigidBody.velocity.x < 0) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		} else if (moveRigidBody.velocity.x > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		/***  Gambiarra - mostra balas***/
		currentGun.ShowAmmoAmount(bulletsText);
	}

	//Shoot
	protected void Shoot () {
		shootDirection = getInputJoyRight ();

		float angle = Mathf.Rad2Deg * Mathf.Atan2(shootDirection.y, shootDirection.x);
		if (Mathf.Abs(angle) > 90)
			transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180, 180-angle);
		else
			transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, angle);

		if (InputManager.ShootButton(inputSource))
			currentGun.Shoot(shootDirection, id);
	}

	//Dash
	protected void Dash () {
		if (InputManager.DashButton(inputSource) < 0.0f && canDash) {
			dashDirection = getInputJoyLeft ();
			myRigidBody.AddForce ((dashDirection * 10), ForceMode2D.Impulse );

		}
	}

	//Super
	protected virtual void Super () {}

	//Super Input
	protected void SuperInput () {
		if (InputManager.SuperButton(inputSource)){
			Super();
		}
	}

	protected Vector2 getInputJoyRight (){
		return InputManager.JoyRight(inputSource, gameObject);
	}

	Vector2 getInputJoyLeft (){
		return InputManager.JoyLeft(inputSource);
	}



	//Die
	protected bool Die () {
		if (life <= 0) {
			alive = false;
			if (speed > 0) {
				speed--;
			}
		}
		return alive;
	}


	//Collision Handling

}
