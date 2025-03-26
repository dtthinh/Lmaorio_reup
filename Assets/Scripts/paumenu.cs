using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class paumenu : MonoBehaviour {
	public bool paused = false;
	public GameObject pauseUI;

	// Use this for initialization
	void Start () {
		pauseUI.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;

		}

		if (paused)
		{
			pauseUI.SetActive(true);
			Time.timeScale = 0;
		}

		if (paused == false)
		{
			pauseUI.SetActive(false);
			Time.timeScale = 1;
		}


	}
	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void GoToMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
}