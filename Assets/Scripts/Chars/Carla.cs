using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carla : Player {

	// Use this for initialization
	void Start () {
		id = 2;
		alive = true;
		canDash = true;
		life = maxLife = 80;
		speed = 13;
		myRigidBody = GetComponent<Rigidbody2D> ();	}

	// Update is called once per frame
	void Update () {
		if (alive) {
			base.Die ();
			base.Move (moveDirection, this.myRigidBody);
			Shoot ();
			Dash ();
			SuperInput ();
		}

	}

	protected override void Super ()
	{
		Debug.Log ("Super");
	}
}
