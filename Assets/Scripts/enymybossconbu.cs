using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enymybossconbu : MonoBehaviour {
	public float enemyspeed;
	Rigidbody2D enemyRB;
	Animator enemyAnim;
	public GameObject enemyGraphic;
	bool fackingRight = true;
	float fackingTime = 5f;
	float nextFlip = 0f;
	bool canFlip = true;

	void Awake(){
		enemyRB = GetComponent<Rigidbody2D> ();
		enemyAnim = GetComponentInChildren<Animator> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlip) {
			nextFlip = Time.time + fackingTime;
			flip ();
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (fackingRight && other.transform.position.x < transform.position.x) {
				flip ();
			} else if (!fackingRight && other.transform.position.x > transform.position.x) {
				flip ();
			}
			canFlip = false;
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if (!fackingRight)
				enemyRB.AddForce (new Vector2 (-1, 0) * enemyspeed);
			else
				enemyRB.AddForce (new Vector2 (1, 0) * enemyspeed);
			enemyAnim.SetBool ("Run", true);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			canFlip = true;
			enemyRB.linearVelocity = new Vector2 (0, 0);
			enemyAnim.SetBool ("Run", false);
		}
	}
	void flip(){
		if (!canFlip)
			return;
		fackingRight = !fackingRight;
		Vector3 theScale = enemyGraphic.transform.localScale;
		theScale.x *= -1;
		enemyGraphic.transform.localScale = theScale;
	}
}
