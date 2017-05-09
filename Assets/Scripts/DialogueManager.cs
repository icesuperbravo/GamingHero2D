using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;

	public Text inputText;
	public Text hint;

	public string[] dialogueLines;
	public int currentLine;
	public int taskNumber;

	public bool dialogueActive;

	private TaskOneUI taskOne;



	// Use this for initialization
	void Start () {
		dBox.SetActive (false);
		taskOne = FindObjectOfType<TaskOneUI> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (dialogueActive && Input.GetKeyDown (KeyCode.Space)) 
		{
			if (currentLine >= dialogueLines.Length-1) 
			{
				dBox.SetActive (false);
				dialogueActive = false;
				taskNumber++;
				switch (taskNumber) 
				{
				case 1:
					taskOne.ShowBox();
					currentLine = 0;
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 5:
					break;
				}
			} else {
				currentLine++;
				Debug.Log (currentLine);
				inputText.text = dialogueLines [currentLine];
			}
		}
	}

	public void ShowBox() 
	{
		dialogueActive = true;
		dBox.SetActive (true);
		Debug.Log ("Dialogue Active");
	}

	public void HideBox() 
	{
		dialogueActive = false;
		dBox.SetActive (false);
		Debug.Log ("Dialogue NOT Active");
	}
}
