using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public bool grounded = true;
	public static bool pandaExists=false;

	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs ((Input.GetAxisRaw ("Horizontal")+Input.GetAxisRaw ("Vertical")) * moveSpeed * Time.deltaTime));
		anim.SetBool ("Grounded", grounded);

//		Debug.Log (SceneManager.GetActiveScene ().buildIndex);
		if (SceneManager.GetActiveScene ().buildIndex == 2 && pandaExists == false) 
		{
			Destroy (gameObject);
			pandaExists = true;
		}	
		
	}

	void FixedUpdate()
	{
		//Moving the player
		float h = 0.7f;
		float v = Input.GetAxisRaw ("Vertical");

		if (h > 0.5f || h < -0.5f)
			rb2d.velocity = new Vector2 (h * moveSpeed, rb2d.velocity.y);
//		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) 
//			rb2d.velocity = new Vector2 (rb2d.velocity.x, v * moveSpeed);

		if (h < 0.5f && h > -0.5f)
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
//		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) 
//			rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
	}
}


