using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
	public int LevelToLoad;
	public string[] dialogueLines;

	private DialogueManager dManager;


	void Start() 
	{
		dManager = FindObjectOfType<DialogueManager> ();
	}
		
	void OnTriggerEnter2D(Collider2D col) 
	{
		dManager.dialogueLines = dialogueLines;
		dManager.currentLine = 0;
		if (col.CompareTag ("Player")) 
		{
			dManager.hint.text = "O.O";
			dManager.ShowBox();

		}
	}
	void OnTriggerStay2D(Collider2D col) {
		if (col.CompareTag ("Player")) 
		{
			if (Input.GetKeyDown ("e")) {
				SceneManager.LoadScene(LevelToLoad);
				dManager.HideBox();
			}
		}

	}
	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			dManager.HideBox();
		}
	}
}
