using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskOneUI : MonoBehaviour {

	public GameObject taskOne;
	public Text story;
	public string[] storyLines; 
	public int currentLine;

	// Use this for initialization
	void Start () {
		taskOne.SetActive (false);
		currentLine = 0;
		story.text = storyLines [currentLine];

	}

	// Update is called once per frame
	void Update () 
	{
		if (taskOne.activeInHierarchy == true) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				if (currentLine >= storyLines.Length-1) 
				{
					taskOne.SetActive (false);
					currentLine = storyLines.Length;
				} else {
					currentLine++;
					story.text = storyLines [currentLine];
				}
			}
		}

	}


	public void ShowBox()   
	{
		taskOne.SetActive (true);
		Time.timeScale = 0; //Setting the time to 0
	}

	public void HideBox()
	{
		taskOne.SetActive (false);
	    Time.timeScale = 1; //Setting the time to 0

	}


	public void Option1 ()
	{
		Debug.Log("You click option1");
		//taskOne.SetActive (false);
	}

	public void Option2 ()
	{
		Debug.Log("You click option2");
	}

}
