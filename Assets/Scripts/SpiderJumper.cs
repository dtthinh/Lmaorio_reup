using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour {
	public Play player;
	public float forceY = 300f;

	private Rigidbody2D myBody;
	private Animator anim;

	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}



	// Use this for initialization
	void Start () {
		StartCoroutine (Attack ());
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Play>();
	}

	IEnumerator Attack(){
		yield return new WaitForSeconds (Random.Range (2, 7));

		forceY = Random.Range (250f, 500f);

		myBody.AddForce (new Vector2 (0, forceY));

		anim.SetBool ("actanknhen", true);

		yield return new WaitForSeconds (.7f);

		StartCoroutine (Attack ());

	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			player.Damage(2);
		}

		if (target.tag == "Ground") {
			anim.SetBool("actanknhen",false);
		}
	}
	// Update is called once per frame
	void Update () {

	}
}

