﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhim : MonoBehaviour {
	[SerializeField]
	private Transform startPos, endPos;

	private bool collision;

	public float speed = 1f;

	private Rigidbody2D myBody;

	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {

	}

	void ChangeDirection(){
		collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

		Debug.DrawLine (startPos.position, endPos.position, Color.green);

		if (!collision) {
			Vector3 temp = transform.localScale;
			if(temp.x ==1f){
				temp.x = -1f;
			}else{
				temp.x = 1f;
			}

			transform.localScale = temp;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move ();
		ChangeDirection ();
	}

	void Move(){
		myBody.linearVelocity = new Vector2 (transform.localScale.x, 0) * -speed;
	}

}