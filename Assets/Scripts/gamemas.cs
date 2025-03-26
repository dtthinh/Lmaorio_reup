using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemas : MonoBehaviour {

	public int keyhd = 0;

	public Text pointtext;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		pointtext.text = (keyhd +" X 2");
	}
}
