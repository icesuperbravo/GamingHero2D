using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStartPoint : MonoBehaviour {

	private GameObject player;
	private GameObject mainCamera;

//	private DialogueManager dm;
	private CameraFollow cameraFollow;
	private PlayerController playerController;
	private Rigidbody2D rigi;



	private Scene currentScene;
	private int currentSceneIndex;
	private int previousSceneIndex;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = transform.position;


		currentSceneIndex = currentScene.buildIndex;

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, mainCamera.transform.position.z);
		cameraFollow = mainCamera.GetComponent<CameraFollow> ();


		//gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
		//gm.InputText.text = ("");

	}
	
	
	// Update is called once per frame
	void Update () 
	{
		currentScene = SceneManager.GetActiveScene ();
		currentSceneIndex = currentScene.buildIndex;
		if (currentSceneIndex != previousSceneIndex && currentSceneIndex == 1) {
			cameraFollow.minCameraPos = new Vector3 (-1.19f, -0.72f, mainCamera.transform.position.z); 
			cameraFollow.maxCameraPos = new Vector3 (-0.12f, 0.1f, mainCamera.transform.position.z); 

			playerController = player.GetComponent<PlayerController> ();
			Destroy (playerController);
			player.AddComponent<PlayerController1> ();

			rigi = player.GetComponent<Rigidbody2D> ();
			rigi.gravityScale = 0.0f;

			//gm.InputText.text=("Monkey: Come to Talk to me! I will help you escape the cage!");
		}
		previousSceneIndex = currentSceneIndex;
	}
		
}
