using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonkeyController : MonoBehaviour {

	private DialogueManager dManager;

	public string[] dialogueLines;


	void Start() 
	{
		dManager = FindObjectOfType<DialogueManager> ();
		dManager.hint.text = "Press Space to Continue";

	}

	void Update()
	{
//		if (dManager.dialogueActive ==false && stayCollide == true) 
//		{
//			dManager.HideBox ();
//			taskOne.ShowBox ();
//
//		}
//		if (taskOne.taskCompleted && !dManager.dialogueActive) 
//		{
//			taskOne.HideBox ();
//			dManager.currentLine = 0;
//			dManager.dialogueLines = respondLines;
//			dManager.ShowBox ();
//			taskOne.taskCompleted = false;
//
//
//		}

	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		
		if (col.CompareTag ("Player")) 
		{
			dManager.dialogueLines = dialogueLines;
			dManager.currentLine = 0;
			dManager.inputText.text = dialogueLines [dManager.currentLine];
			dManager.ShowBox ();
		}

	}
		

	void OnTriggerStay2D(Collider2D col) 
	{
//		dManager.dialogueLines = dialogueLines;
//		dManager.currentLine = 0;
//		if (col.CompareTag ("Player")) 
//		{
//			dManager.ShowBox ();
//		}

	}
	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) 
		{
			dManager.HideBox (); 
		}
	}
	 	
}
