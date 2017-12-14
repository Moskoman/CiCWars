using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladeira : Player {

	// Use this for initialization
	void Start () {
		id = 1;
		alive = true;
		canDash = true;
		life = 100;
		speed = 10;
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
