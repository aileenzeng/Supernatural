using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeanScript : MonoBehaviour {

	private float gameTicks;	//timing

	//variables for input
	private static readonly string RIGHT = "right";
	private static readonly string LEFT = "left";
	private static readonly string JUMP = "jump";
	private static readonly string SHOOT = "shoot";

	//player mechanics
	private Rigidbody2D rb;
	public float horizSpeed;
	public float jumpSpeed;
	public float gravity;
	public LayerMask groundLayers;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameTicks += Time.deltaTime;
		controlPlayer ();
		playerMotion ();

	}

	//Handles user control for player
	void controlPlayer() {
		//moves player left
		if (Input.GetButton (LEFT) == true) 
		{
			transform.Translate (Vector2.left * horizSpeed * Time.deltaTime);
		}

		//moves player right
		if (Input.GetButton (RIGHT) == true) {
			transform.Translate (Vector2.right * horizSpeed * Time.deltaTime);
		}

		//makes player jump
		if (Input.GetButton (JUMP) == true && isGrounded) 
		{
			rb.velocity = new Vector2 (0, 10.0f);
		}

		//makes player shoot
		if (Input.GetButton (SHOOT) == true) 
		{
			Debug.Log ("SPACE pressed");
			//create code to release a bullet - create class for it
		}
	}

	//Handles non-user player movement
	void playerMotion() {
		//Checks to see if the player is touching the ground
		isGrounded = Physics2D.Raycast (transform.position, Vector2.down, GetComponent<Collider2D> ().bounds.size.y / 2 + 0.2f, groundLayers);
		//adds gravity to the player
		rb.AddForce(Vector2.down * gravity * rb.mass);			
	}
}
