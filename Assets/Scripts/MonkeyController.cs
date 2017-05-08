using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonkeyController : MonoBehaviour {

	private DialogueManager dManager;

	private TaskOneUI taskOne;

	public string[] dialogueLines;

	void Start() 
	{
		dManager = FindObjectOfType<DialogueManager> ();
		taskOne= FindObjectOfType<TaskOneUI> ();

	}

	void Update()
	{
		if (dManager.currentLine == dialogueLines.Length) 
		{
			dManager.HideBox ();
			taskOne.ShowBox ();
			//dManager.currentLine = 0;

		}

	}
		

//	void OnTriggerEnter2D(Collider2D col) 
//	{
//		if (col.CompareTag ("Player")) 
//		{
//				dManager.ShowBox (dialogue);
//		}
//
//	}
	void OnTriggerStay2D(Collider2D col) 
	{
		dManager.dialogueLines = dialogueLines;
		dManager.currentLine = 0;
		if (col.CompareTag ("Player")) 
		{
			dManager.hint.text = "Press Space to Continue";
			dManager.ShowBox ();

		}

	}
	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) 
		{
			dManager.HideBox (); 
		}
	}
}
