using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chet : MonoBehaviour {
	public Play player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Play>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			player.Damage (2);
		}
	}
}
