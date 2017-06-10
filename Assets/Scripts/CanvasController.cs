using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

	public GameObject canvas;
	private static bool canvasExists;
	// Use this for initialization
	void Start () 
	{
//canvas.SetActive (false);
		
//		if (!canvasExists) 
//		{
//			canvasExists = true;
//			Debug.Log (canvasExists);
//			DontDestroyOnLoad (transform.root.gameObject); //http://answers.unity3d.com/questions/441721/dontdestroyonload-not-working.html	
//
//		} else {
//			Destroy (transform.root.gameObject);
//			Debug.Log ("Destory the object");
//		}
		DontDestroyOnLoad (transform.root.gameObject); //http://answers.unity3d.com/questions/441721/dontdestroyonload-not-working.html	
	}


	void Update () 
	{
		//Debug.Log (SceneManager.GetActiveScene ().buildIndex);
		if (SceneManager.GetActiveScene ().buildIndex == 2 && canvasExists == false) 
		{
			Destroy (transform.root.gameObject);
			canvasExists = true;
		}	
	}
}
