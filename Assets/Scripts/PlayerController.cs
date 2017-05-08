﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	public float jumpPower;
	public bool grounded;

	private Rigidbody2D rb2d;
	private Animator anim;
	private float maxMoveSpeed = 3.0f;

	private static bool pandaExists;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		if (!pandaExists) {
			pandaExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}


	}

	// Update is called once per frame
	void Update () {
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));
		//Space--> jump operation, which makes the panda jump when press space button;
		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			rb2d.AddForce (Vector2.up * jumpPower );

		}


	}
	void FixedUpdate()
	{
		//Moving the player
		float h = Input.GetAxisRaw ("Horizontal");
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f)
			rb2d.velocity = new Vector2 (h * moveSpeed, rb2d.velocity.y);

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f)
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		
		if (rb2d.velocity.x > maxMoveSpeed) 
		{
			rb2d.velocity = new Vector2 (maxMoveSpeed, rb2d.velocity.y);
		}


		if (rb2d.velocity.x < -maxMoveSpeed) 
		{
			rb2d.velocity = new Vector2 (-maxMoveSpeed, rb2d.velocity.y);
		}

	}
}
