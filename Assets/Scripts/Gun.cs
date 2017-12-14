using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gun : MonoBehaviour {

	protected int maxAmmo, roundCapacity, currentAmmo, ammoOnRound;
	protected float reloadTime, coolDownWeapon, fireRate;
	protected bool canShoot;
	public int Id;
	public GameObject bullet;
	public GameObject shotSpawn;
	public AudioSource reloadSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shoot (Vector2 bulletDirection, int shooterId) {
		if (ammoOnRound <= 0) {
			canShoot = false;
			Reload ();
		}
		if (canShoot == true && coolDownWeapon <= Time.time) {
			Quaternion bulletRotation = Quaternion.Euler (new Vector3(bulletDirection.x * Mathf.Rad2Deg, bulletDirection.y * Mathf.Rad2Deg, 0));
			Instantiate (bullet, shotSpawn.transform.position, bulletRotation);
			bullet.GetComponent<Bullet> ().bulletDirection = bulletDirection;
			bullet.GetComponent<Bullet> ().shooterId = shooterId;
			coolDownWeapon = fireRate + Time.time;
			ammoOnRound--;
			currentAmmo--;
			Debug.Log ("current: " + currentAmmo);
			Debug.Log ("onRound; " + ammoOnRound);
		}
	}

	public void Reload () {
		reloadSound.Play ();
		if (maxAmmo >= roundCapacity) {
			ammoOnRound = roundCapacity;
			maxAmmo -= roundCapacity;
			Invoke ("SetCanShootToTrue", reloadTime);
		} else
			ammoOnRound = maxAmmo;
			Invoke ("SetCanShootToTrue", reloadTime);
	}

	private void SetCanShootToTrue () {
		canShoot = true;
	}
}
