using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskOneUI : MonoBehaviour {

	public GameObject taskOne;
	public Text story;

	public string[] storyLines;
	public string[] respondLines;
	public int currentLine;

	public bool taskActive;

	private PlayerGradingSystem points;
	private DialogueManager dialogue;

	// Use this for initialization
	void Start () {
		points= FindObjectOfType<PlayerGradingSystem> ();
		dialogue = FindObjectOfType<DialogueManager> ();

		taskOne.SetActive (false);
		currentLine = 0;
		story.text = storyLines [currentLine];

	}

	// Update is called once per frame
	void Update () 
	{
		
			if (taskActive && Input.GetKeyDown (KeyCode.Space)) 
			{
				if (currentLine >= storyLines.Length) 
				{
//					taskOne.SetActive (false);
//					taskActive = false;
				    HideBox();
					//currentLine = storyLines.Length;
				} else {
					currentLine++;
					story.text = storyLines [currentLine-1];
				}
			}

	}


	public void ShowBox()   
	{
		taskOne.SetActive (true);
		taskActive = true;
		Debug.Log("task one active");
	}

	public void HideBox()
	{
		taskOne.SetActive (false);
		taskActive = false;
		Debug.Log("task one NOT active");
	}

	public void SwitchToDialogue ()
	{
		dialogue.currentLine = 0;
		dialogue.dialogueLines = respondLines;
		dialogue.inputText.text = respondLines[dialogue.currentLine];
		dialogue.ShowBox ();
	}
		
	public void Option1 ()
	{
		Debug.Log("You click option1");
		HideBox ();
		points.cooperation = points.cooperation + 1;
		SwitchToDialogue ();
	}

	public void Option2 ()
	{
		Debug.Log("You click option2");
		HideBox ();
		points.cooperation = points.cooperation + 2;
		SwitchToDialogue ();
	}

	public void Option3 ()
	{   
		Debug.Log("You click option3");
		HideBox ();
		points.cooperation = points.cooperation + 3;
		SwitchToDialogue ();
	}


}
