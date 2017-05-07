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

	public bool dialogueActive;



	// Use this for initialization
	void Start () {
		dBox.SetActive (false);

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
				currentLine = dialogueLines.Length;
			} else {
				currentLine++;
				inputText.text = dialogueLines [currentLine];
			}
		}
	}

	public void ShowBox() 
	{
		inputText.text = dialogueLines [currentLine];
		dialogueActive = true;
		dBox.SetActive (true);
	}

	public void HideBox() 
	{
		dialogueActive = false;
		dBox.SetActive (false);
	}
}
