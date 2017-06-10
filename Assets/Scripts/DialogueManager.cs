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
//	private TaskTwoUI taskTwo;
	private TaskThreeUI taskThree;
	private TaskFourUI taskFour;

	 
	private  PhoneController phoneController;
	private  MapController mapController;





	// Use this for initialization
	void Start () 
	{
		dBox.SetActive (false);
		taskOne = FindObjectOfType<TaskOneUI> ();
//		taskTwo = FindObjectOfType<TaskTwoUI> ();
		taskThree =  FindObjectOfType<TaskThreeUI> ();
		taskFour =  FindObjectOfType<TaskFourUI> ();





	}
	
	// Update is called once per frame
	void Update () 
	{   
		if (dialogueActive && Input.GetMouseButtonDown(0)) 
		{
			//Dialogue controll in the Scene 0
			if (SceneManager.GetActiveScene ().buildIndex == 0) 
			{
				if (currentLine >= dialogueLines.Length - 1) 
				{
					HideBox ();
					preventTasks = true;
				}
					
				else {
					currentLine++;
					Debug.Log (currentLine);
					inputText.text = dialogueLines [currentLine];
				}
			}

			//Dialogue controll in the Scene 1
			if (SceneManager.GetActiveScene ().buildIndex == 1) 
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
						//					taskTwo.ShowBox ();
						//					taskTwo.currentLine = 0;
						phoneController =  FindObjectOfType<PhoneController> ();
						//Debug.Log (phoneController);
						phoneController.phoneAnimEnabled = true;
						phoneController.PlayAnimation ();
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
						mapController = FindObjectOfType<MapController> ();
						mapController.mapAnimEnabled = true;
						mapController.PlayAnimation ();
						currentLine = 0;
						break;
					default:
						preventTasks = true;
						break;
					}
				} else {
					currentLine++;
					Debug.Log (currentLine);
					inputText.text = dialogueLines [currentLine];
				}
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
