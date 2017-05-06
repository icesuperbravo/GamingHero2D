using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;

	void Start() {
		PauseUI.SetActive (false);  //Pause UI will be disabled when game starts
		DontDestroyOnLoad (transform.root.gameObject); //http://answers.unity3d.com/questions/441721/dontdestroyonload-not-working.html	
	}

	void Update() {
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}
		if (PauseUI == null) {
			Destroy (gameObject);
		} else 
		{
			if (paused) {
				PauseUI.SetActive (true);
				Time.timeScale = 0; //Setting the time to 0
			}

			if (!paused) {
				PauseUI.SetActive (false);
				Time.timeScale = 1;  
			}
		}


	}
	public void Resume() {
		paused = false;
	}

	public void Restart() {
		SceneManager.LoadScene("Main");
	}

	public void Quit() {
		Application.Quit();
	}
}
