using UnityEngine;
using System.Collections;

public class LevelMenuController : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel("Main1");
	}
	public void PlayGame2(){
		Application.LoadLevel("Main2");
	}
	public void PlayGame3(){
		Application.LoadLevel("Main3");
	}
	public void PlayGame4(){
		Application.LoadLevel("Main4");
	}
	public void PlayGame5(){
		Application.LoadLevel("Main5");
	}
	public void BackToMenu(){
		Application.LoadLevel("MainMenu");
	}

}
