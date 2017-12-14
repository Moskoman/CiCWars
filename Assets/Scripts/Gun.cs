using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gun : MonoBehaviour {

	protected int maxAmmo, roundCapacity, ammoOnRound;
	public int currentAmmo;
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
			Quaternion bulletRotation = Quaternion.Euler (0, 0, Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg + 90);
			GameObject newBullet = Instantiate (bullet, shotSpawn.transform.position, bulletRotation);
			newBullet.GetComponent<Bullet> ().bulletDirection = bulletDirection;
			newBullet.GetComponent<Bullet> ().shooterId = shooterId;
			coolDownWeapon = fireRate + Time.time;
			ammoOnRound--;
			currentAmmo--;
		}
	}

	public void Reload () {
		reloadSound.Play ();
		if (currentAmmo >= roundCapacity) {
			ammoOnRound = roundCapacity;
			Invoke ("SetCanShootToTrue", reloadTime);
		} else if (currentAmmo < roundCapacity && currentAmmo > 0) {
			ammoOnRound = maxAmmo;
			Invoke ("SetCanShootToTrue", reloadTime);
		}
	}

	private void SetCanShootToTrue () {
		canShoot = true;
	}
}
