using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
	public int LevelToLoad;
	public string[] dialogueLines;

	private DialogueManager dManager;
	private MusicManager mManager;


	void Start() 
	{
		dManager = FindObjectOfType<DialogueManager> ();
		mManager = FindObjectOfType<MusicManager> ();
		dManager.hint.text = "O.O";
		dManager.dialogueLines = dialogueLines;

	}
		
	void OnTriggerEnter2D(Collider2D col) 
	{
		dManager.dialogueLines = dialogueLines;
		dManager.currentLine = 0;
		dManager.inputText.text = dialogueLines [dManager.currentLine];
		if (col.CompareTag ("Player")) 
		{
			dManager.ShowBox ();
		}

	}
	void OnTriggerStay2D(Collider2D col) {
		if (col.CompareTag ("Player")) 
		{
			if (Input.GetKeyDown ("e")) {
				SceneManager.LoadScene(LevelToLoad);
				dManager.HideBox();
				mManager.SwitchTrack (1);
			}
		}

	}
	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			dManager.HideBox();
		}
	}
}
