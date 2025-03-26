using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycoi : MonoBehaviour {
	public Rigidbody2D r2;
	public gamemas gm;
	// Use this for initialization
	void Start () {
		r2 = gameObject.GetComponent<Rigidbody2D>();
		gm = GameObject.FindGameObjectWithTag("gamemas").GetComponent<gamemas>();
	}

	// Update is called once per frame
	void Update () {

	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("KeyHD"))
		{
			Destroy(col.gameObject);
			gm.keyhd += 1;
		}
	}
}
