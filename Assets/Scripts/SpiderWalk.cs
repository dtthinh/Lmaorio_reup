using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalk : MonoBehaviour {
	private Rigidbody2D myBody;
	public gamemaster gm;
	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
	}
		

	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player") {
			GameObject.Find("GamePlay Control").GetComponent<GameplayController>().PlayerDied();
			Destroy(target.gameObject);
		}
		if (PlayerPrefs.GetInt("highscore") < gm.points)
			PlayerPrefs.SetInt("highscore", gm.points);
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Coins"))
		{
			Destroy(col.gameObject);
			gm.points += 1;
		}
	}

}