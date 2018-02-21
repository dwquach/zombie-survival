using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void goToMainMenu(){
		SceneManager.LoadScene ("Main Menu");
	}
	public void PlayGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Main");
	}


	public void QuitGame(){
		Application.Quit ();
	}

	public void pauseGame(){
		Time.timeScale = 0;
	}

	public void ContinueGame(){
		Time.timeScale = 1;
		Debug.Log ("game time back to 1");
	}
}
