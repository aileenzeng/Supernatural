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
    private Vector3 currPos;

	//weapon, health
	public GameObject bullet;
	private Transform ts;
	private int health;
	public int gunReloadTime;
	private float gunTime;


	//misc
	private float buttonTime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;
		ts = GetComponent<Transform> ();

		health = STARTHEALTH; 
	}
	
	// Update is called once per frame
	void Update () {
		gameTicks += Time.deltaTime;
		gunTime += Time.deltaTime;
		buttonTime += Time.deltaTime;

        //currPos = new Vector2(GetComponent<Transform>().transform.x, GetComponent<Transform>().transform.y);
        //Debug.Log("Player position: " + currPos);
		movePlayer();
		testFunction();
        
		if (health == 0) { kill (); }

	}

	//Handles user control for player
	void movePlayer() 
	{
		//moves player left - 'A'
		if (Input.GetButton (LEFT) == true) 
		{
			transform.Translate (Vector2.left * horizSpeed * Time.deltaTime);
		}

		//moves player right - 'D'
		if (Input.GetButton (RIGHT) == true) {
			transform.Translate (Vector2.right * horizSpeed * Time.deltaTime);
		}

		//makes player jump - 'W'
		if (Input.GetButton (JUMP) == true && isGrounded) 
		{
			rb.velocity = new Vector2 (0, 10.0f);
		}

		//makes player shoot - 'space'
		if (Input.GetButton (SHOOT) == true && gunTime > gunReloadTime) 
		{
			Debug.Log ("SHOT!");
			gunTime = 0.0f;
			Instantiate (bullet);
			//create code to release a bullet - create class for it
		}

		//Checks to see if the player is touching the ground
		isGrounded = Physics2D.Raycast (transform.position, Vector2.down, GetComponent<Collider2D> ().bounds.size.y / 2 + 0.2f, groundLayers);
		//adds gravity to the player
		rb.AddForce(Vector2.down * gravity * rb.mass);	
	}

	//creates a functional display for health... and bullets
	void OnGUI () 
	{
		GUI.Label (new Rect (10, 10, 80, 30), "Health: " + health);
	}

	//use to print out debug messages (that you don't want to spam)
	void testFunction() 
	{
		//'T'
		if (Input.GetButton (TEST) == true && buttonTime > 1.0f) 
		{
			buttonTime = 0.0f;
			Debug.Log (health);
		}
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.name == "Demon") 
		{
			Debug.Log ("bruuuuhhhh");
			subtractHealth (1);
		}
	}
		
	public void kill() 
	{
		Destroy (this.gameObject);
	}

	public void addHealth(int i) 
	{
		health += i;
	}

	public void subtractHealth(int i) 
	{
		health -= i;
	}

	public int getHealth() 
	{
		return health;
	}
		
}
