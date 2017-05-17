using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;

	public Text inputText;
	public Text hint;

	public string[] dialogueLines;
	public int currentLine;
	public int taskNumber;

	public bool dialogueActive;
	public bool preventTasks;

	private TaskOneUI taskOne;
	private TaskTwoUI taskTwo;
	private TaskThreeUI taskThree;
	private TaskFourUI taskFour;



	// Use this for initialization
	void Start () 
	{
		dBox.SetActive (false);
		taskOne = FindObjectOfType<TaskOneUI> ();
		taskTwo = FindObjectOfType<TaskTwoUI> ();
		taskThree =  FindObjectOfType<TaskThreeUI> ();
		taskFour =  FindObjectOfType<TaskFourUI> ();
	}
	
	// Update is called once per frame
	void Update () 
	{   
		if (dialogueActive && Input.GetKeyDown (KeyCode.Space)&& SceneManager.GetActiveScene().buildIndex ==1 ) 
		{
			if (currentLine >= dialogueLines.Length-1) 
			{
				
				HideBox();
				taskNumber++;
				switch (taskNumber) 
				{
				case 1:
					taskOne.ShowBox ();
					taskOne.currentLine = 0;
					currentLine = 0;
					break;
				case 2:
					taskTwo.ShowBox ();
					taskTwo.currentLine = 0;
					currentLine = 0;
					break;
				case 3:
					taskThree.ShowBox ();
					taskThree.currentLine = 0;
					currentLine = 0;
					break;
				case 4:
					taskFour.ShowBox ();
					taskFour.currentLine = 0;
					currentLine = 0;
					break;
				case 5:
					//ToDo: Connects to Next Cage
					//SceneManager.LoadScene(2);  
					break;
				default:
					preventTasks = false;
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
