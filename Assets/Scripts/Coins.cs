using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
	public Rigidbody2D r2;
	public gamemaster gm;
	public SoundManager sound;
	// Use this for initialization
	void Start () {
		r2 = gameObject.GetComponent<Rigidbody2D>();
		gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
		sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Coins"))
		{
			sound.Playsound("coins");
			Destroy(col.gameObject);
			gm.points += 1;
		}
	}
}
