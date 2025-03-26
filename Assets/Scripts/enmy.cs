using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy : MonoBehaviour {
	public float damage;
	float dameRate = 0.5f;
	public float pushBackFore;
	float nextDamege;
	// Use this for initialization
	void Start () {
		nextDamege = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && nextDamege < Time.time) {
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
			nextDamege = damage + Time.time;
			pushBack (other.transform);
		}
	}
	void pushBack(Transform pushObject){
		Vector2 pushDrirection = new Vector2 (0, (pushObject.position.y - transform.position.y)).normalized;
		pushDrirection *= pushBackFore;
		Rigidbody2D pushBB = pushObject.gameObject.GetComponent<Rigidbody2D> ();
		pushBB.linearVelocity = Vector2.zero;
		pushBB.AddForce (pushDrirection, ForceMode2D.Impulse);
	}
}
