﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private Button resumeGame;

	public void PauseGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		resumeGame.onClick.RemoveAllListeners ();
		resumeGame.onClick.AddListener(()=>ResumeGame());
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void GoToMenu(){
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}

	public void RestartGame(){
		Time.timeScale = 1f;
		Application.LoadLevel ("Main1");
	}

	public void PlayerDied(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		resumeGame.onClick.RemoveAllListeners ();
		resumeGame.onClick.AddListener(()=>RestartGame());
	}

}





















