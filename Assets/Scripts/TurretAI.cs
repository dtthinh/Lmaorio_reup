using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {
	public int curHealth = 100;

	public float distance;
	public float wakerange;
	public float shootinterval;
	public float bulletspeed = 5;
	public float bullettimer;
	public GameObject bullet;
	public Transform target;
	public Transform shootpointL;
	public bool lookingRight = true;
	public SoundManager sound;
	// Use this for initialization
	void Start () {
		sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (target.transform.position.x > transform.position.x)
		{
			lookingRight = true;
		}

		if (target.transform.position.x < transform.position.x)
		{
			lookingRight = false;
		}
		if (curHealth < 0)
		{
			sound.Playsound("destroy");
			Destroy(gameObject);
		}
	}
	public void Attack(bool attackright)
	{
		bullettimer += Time.deltaTime;

		if (bullettimer >= shootinterval)
		{
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();
			if (!attackright)
			{
				GameObject bulletclone;
				bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
				bulletclone.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletspeed;

				bullettimer = 0;
			}
		}
	}

	public void Damage(int dmg)
	{
		curHealth -= dmg;
		gameObject.GetComponent<Animation>().Play("redflash");
	}
}
