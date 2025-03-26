using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {
	public float maxHealth;
	float currentHealth;
	public GameObject blooEF;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void addDamage(float damege){
		if (damege <= 0)
			return;
		currentHealth -= damege;
		if (currentHealth <= 0)
			makeDead ();
	}
	void makeDead(){
		Instantiate (blooEF, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
