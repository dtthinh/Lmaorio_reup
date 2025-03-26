using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamemaster : MonoBehaviour {
	public int points = 0;
	public int highscore = 0;

	public Text pointtext;
	public Text Hightext;
	public Text Inputtext;

	// Use this for initialization
	void Start () {
		Hightext.text = ("" + PlayerPrefs.GetInt("Highscoress"));
		highscore = PlayerPrefs.GetInt("Highscoress", 0);

		if (PlayerPrefs.HasKey("pointss"))
		{
			Scene ActiveScreen = SceneManager.GetActiveScene();
			if (Application.loadedLevel == 0) {
				PlayerPrefs.DeleteKey ("pointss");
				points = 0;
			} else {
				points = PlayerPrefs.GetInt ("pointss");
			}
		}
		if (PlayerPrefs.HasKey ("Highscoress")) {
			highscore = PlayerPrefs.GetInt("Highscoress");
		}
	}

	// Update is called once per frame
	void Update () {
		pointtext.text = ("" + points);
	}
}
