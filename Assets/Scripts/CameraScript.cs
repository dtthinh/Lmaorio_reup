using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform player;
	public float smoothing;
	Vector3 offSet;
	float lowY;
	// Use this for initialization
	void Start () {
		offSet = transform.position - player.position;
		lowY = transform.position.y;

	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = player.position + offSet;
		transform.position = Vector3.Lerp (transform.position, temp, smoothing * Time.deltaTime);
		if (transform.position.y < lowY) {
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}
}
