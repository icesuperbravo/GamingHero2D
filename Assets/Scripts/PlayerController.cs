using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	public float jumpPower;
	public bool grounded;

	private Rigidbody2D rb2d;
	private Animator anim;
	private float maxMoveSpeed = 3.0f;

	//private bool PlayerExists;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		DontDestroyOnLoad (transform.gameObject);
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
		rb2d.AddForce ((Vector2.right * moveSpeed) * h );

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
