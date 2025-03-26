using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyhd : MonoBehaviour {
	public SoundManager sound;
	// Use this for initialization
	void Start () {
		sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
		if (dor.instance != null) {
			dor.instance.collectablesCount++;
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			sound.Playsound("key");
			Destroy(gameObject);

			if(dor.instance != null){
				dor.instance.DecrementCollectables();
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
