﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX1 : MonoBehaviour {

	public int Health = 100;

	// Update is called once per frame
	void Update () {
		if (Health <= 0)
		{
			Destroy(gameObject);
		}
	}

	void Damage(int damage)
	{
		Health -= damage;
		gameObject.GetComponent<Animation>().Play("redflash");
	}
}
