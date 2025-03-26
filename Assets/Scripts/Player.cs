using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float maxSpeed;
	public float jumHeight;
	Rigidbody2D myBody;
	Animator myAnim;
	bool facingRight;
	bool grounded;
	public gamemaster gm;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator> ();
		facingRight = true;
		gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed" , Mathf.Abs (move));
		myBody.linearVelocity = new Vector2 (move * maxSpeed, myBody.linearVelocity.y);
		if(move > 0 && !facingRight){
			flip ();
		}else if (move < 0 && facingRight){
			flip ();
		}
		if(Input.GetKey(KeyCode.Space)){
			if (grounded) {
				grounded = false;
				myBody.linearVelocity = new Vector2 (myBody.linearVelocity.x, jumHeight);
			}
		}
		if (PlayerPrefs.HasKey ("Highscoress")) {
			if (PlayerPrefs.GetInt ("Highscoress") < gm.points) {
				PlayerPrefs.SetInt ("Highscoress", gm.points);
			}
		} else {
			PlayerPrefs.SetInt ("Highscoress", gm.points);
		}
	}
	void flip(){
		facingRight = !facingRight;
		Vector3 TheScale = transform.localScale;
		TheScale.x *= -1;
		transform.localScale = TheScale;
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
}
