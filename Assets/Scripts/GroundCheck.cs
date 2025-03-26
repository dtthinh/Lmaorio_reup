using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public Play player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<Play>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.isTrigger == false)
		player.grounded = true;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.isTrigger == false)
		player.grounded = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.isTrigger == false)
		player.grounded = false;
	}
}
