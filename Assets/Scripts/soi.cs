using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soi : MonoBehaviour {
	public Rigidbody2D r2;
	public gamesoi gm;
	public SoundManager sound;
	// Use this for initialization
	void Start () {
		r2 = gameObject.GetComponent<Rigidbody2D>();
		gm = GameObject.FindGameObjectWithTag("soi").GetComponent<gamesoi>();
		sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
	}

	// Update is called once per frame
	void Update () {

	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("soiHD"))
		{
			sound.Playsound("soi");
			Destroy(col.gameObject);
			gm.soi += 1;
		}
	}
}
