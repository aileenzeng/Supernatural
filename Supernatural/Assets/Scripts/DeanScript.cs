 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeanScript : MonoBehaviour {

	private float gameTicks;	//timing
	private static int STARTHEALTH = 4;
	private static int STARTAMMO = 5;

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
	private bool direction; //right = true, left = false
	public GameObject movingPlatform;
	private bool onPlatform;

	//weapon, health
	public GameObject bullet;
	private int health;
	private int ammo;
	public int gunReloadTime;
	private float gunTime;
	private Vector2 force;

	//misc
	private float buttonTime;
	private SpriteRenderer sr;
	private bool hasWon;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;
		sr = GetComponentInChildren<SpriteRenderer> ();

		health = STARTHEALTH;
		ammo = STARTAMMO;
		direction = true;
		hasWon = false;
	}
	
	// Update is called once per frame
	void Update () {
		gameTicks += Time.deltaTime;
		gunTime += Time.deltaTime;
		buttonTime += Time.deltaTime;

		movePlayer();
		testFunction();
        
		//Debug.Log ("deanscript direction: " + direction);
		if (health == 0 || transform.position.y < -20) { kill (); }

		if (onPlatform) {movePlayerOnPlatform();}

	}

	//Handles user control for player
	void movePlayer() 
	{
		//moves player right - 'D'
		if (Input.GetButton (RIGHT) == true) {
			transform.Translate (Vector2.right * horizSpeed * Time.deltaTime);
			direction = true;
			sr.flipX = false;
		}

		//moves player left - 'A'
		if (Input.GetButton (LEFT) == true) 
		{
			transform.Translate (Vector2.left * horizSpeed * Time.deltaTime);
			direction = false;
			sr.flipX = true;
		}
			
		//makes player jump - 'W'
		if (Input.GetButton (JUMP) == true && isGrounded) 
		{
			rb.velocity = new Vector2 (0, 10.0f);
		}

		//makes player shoot - 'space'
		if (Input.GetButton (SHOOT) == true && gunTime > gunReloadTime && ammo > 0) 
		{
			shootBullet();
			ammo--;
		}

		//Checks to see if the player is touching the ground
		isGrounded = Physics2D.Raycast (transform.position, Vector2.down, GetComponent<Collider2D>().bounds.size.y / 2 + 0.2f, 
			groundLayers);
		//adds gravity to the player
		rb.AddForce(Vector2.down * gravity * rb.mass);	
	}

	//creates a functional display for health... and bullets
	//replace with something better lookng eventually
	void OnGUI () 
	{
		GUI.Label (new Rect (10, 10, 80, 30), "Health: " + health);
		GUI.Label (new Rect (100, 10, 80, 30), "Ammo: " + ammo);
		if (hasWon) { GUI.Label (new Rect (40, 40, 100, 100), "You won!"); }
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

	//move to bullet class?
	void shootBullet() {
		gunTime = 0.0f;

		float toAdd = 0;
		float rotation = 0.0f;

		//The direction the bullet will go in
		if (direction) {
			force = Vector2.right;	//change so bullet changes direction
			toAdd = 0.5f;
		}

		if (!direction) {
			force = Vector2.left;
			toAdd = -0.5f;
		}

		Vector2 pos = new Vector2(transform.position.x + toAdd, transform.position.y);
		var newBullet = Instantiate(bullet, pos, Quaternion.Euler(0, 0, rotation));

		var rbBullet = newBullet.GetComponent<Rigidbody2D>();
		rbBullet.velocity = newBullet.GetComponent<BulletScript>().speed * force;
		
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.tag == "Demon") 
		{
			subtractHealth (1);
			Debug.Log ("Hello");
		}

		if (col.gameObject.tag == "Salt") 
		{
			if (ammo < 5) 
			{
				ammo++;
			}
		}

		if (col.gameObject.tag == "Win") 
		{
			hasWon = true;
		}

		if (col.gameObject.tag == "Beer" && health < 4) 
		{
			addHealth(1);
		}

		if (col.gameObject.tag == "Spike" && health > 0) 
		{
			subtractHealth(1);
		}

		if (col.gameObject.tag == "Moving Ground" && isGrounded) {
			onPlatform = true;
		}

	}

	void movePlayerOnPlatform() {

		Debug.Log(movingPlatform.GetComponent<MovingPlatform> ().test ());
		transform.Translate (movingPlatform.GetComponent<MovingPlatform> ().getPlatformVector());
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

	public bool getDirection()
	{
		return direction;
	}
		
}
