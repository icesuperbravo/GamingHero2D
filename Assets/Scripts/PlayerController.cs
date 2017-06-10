using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	public float jumpPower;
	public bool grounded;
	public string[] dialogueLines;

	private Rigidbody2D rb2d;
	private Animator anim;
	private float maxMoveSpeed = 3.0f;
	private DialogueManager dManager;

	private static bool pandaExists;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		dManager = FindObjectOfType<DialogueManager> ();
		dManager.dialogueLines = dialogueLines;
		dManager.currentLine = 0;
		dManager.hint.text = "Click to continue!";
		dManager.inputText.text = dialogueLines [dManager.currentLine];
		dManager.ShowBox ();

		DontDestroyOnLoad (transform.gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));
		//Space--> jump operation, which makes the panda jump when press space button;
		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			rb2d.AddForce (Vector2.up * jumpPower );
		}
		if (SceneManager.GetActiveScene ().buildIndex == 2 && !pandaExists) 
		{
			Destroy (gameObject);
			pandaExists = true;
		}
	}


	void FixedUpdate()
	{
		if (dManager.preventTasks) 
		{
			//Moving the player
			//float h = Input.GetAxisRaw ("Horizontal");
			float h = 0.7f;
			if (h > 0.5f || h < -0.5f)
				rb2d.velocity = new Vector2 (h * moveSpeed, rb2d.velocity.y);
			if (h < 0.5f && h > -0.5f)
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
}
