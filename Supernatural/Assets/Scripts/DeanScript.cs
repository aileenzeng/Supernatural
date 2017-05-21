using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeanScript : MonoBehaviour {

	private float gameTicks;	//timing
	private static int STARTHEALTH = 3;

	//strings for input
	private static readonly string RIGHT = "right";
	private static readonly string LEFT = "left";
	private static readonly string JUMP = "jump";
	private static readonly string SHOOT = "shoot";
	private static readonly string TEST = "test";

	//player mechanics
	private Rigidbody2D rb;
	public float horizSpeed;
	public float jumpSpeed;
	public float gravity;
	public LayerMask groundLayers;
	private bool isGrounded;

	//weapon, health
	private int health;
	public int gunReloadTime;
	private float gunTime;


	//misc
	private float buttonTime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;

		health = STARTHEALTH; 
	}
	
	// Update is called once per frame
	void Update () {
		gameTicks += Time.deltaTime;
		gunTime += Time.deltaTime;
		buttonTime += Time.deltaTime;

		movePlayer();
		testFunction();

	}

	//Handles user control for player
	void movePlayer() {
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
		if (Input.GetButton (SHOOT) == true && gunTime > gunReloadTime) 
		{
			Debug.Log ("SHOT!");
			gunTime = 0.0f;
			//create code to release a bullet - create class for it
		}

		//Checks to see if the player is touching the ground
		isGrounded = Physics2D.Raycast (transform.position, Vector2.down, GetComponent<Collider2D> ().bounds.size.y / 2 + 0.2f, groundLayers);
		//adds gravity to the player
		rb.AddForce(Vector2.down * gravity * rb.mass);	
	}

	//use to print out debug messages (that you don't want to spam)
	void testFunction() {
		if (Input.GetButton (TEST) == true && buttonTime > 1.0f) {
			Debug.Log ("Hello!");
			buttonTime = 0.0f;
		}
	}

	public void addHealth(int i) {
		health += i;
	}

	public void subtractHealth(int i) {
		health -= i;
	}

	public int getHealth() {
		return health;
	}
		
}
