﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;

	public GameObject player;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;


	private static bool cameraExists;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");

//		if (!cameraExists) {
//	        cameraExists = true;
//			DontDestroyOnLoad (transform.gameObject);
//		} else {
//			Destroy (gameObject);
//		}
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log (SceneManager.GetActiveScene ().buildIndex);
		if (SceneManager.GetActiveScene ().buildIndex == 2 && cameraExists == false) 
		{
			Destroy (gameObject);
			cameraExists = true;
		}	
	}

	void FixedUpdate() 
	{
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds) 
		{
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x), Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y), Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}

	public void SetMinCamPosition() 
	{
		minCameraPos = gameObject.transform.position;
	}

	public void SetMaxCamPosition() 
	{
		maxCameraPos = gameObject.transform.position;
	}
}
