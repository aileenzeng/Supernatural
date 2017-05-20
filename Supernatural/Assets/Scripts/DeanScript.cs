using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeanScript : MonoBehaviour {
	public GameObject dean;

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
		movePlayer ();

	}

	//Controls player movement
	void movePlayer() {
		//AUTOMATIC
		//Tell if there is anything in a sphere shape below the player
		RaycastHit hitInfo;
		//isGrounded = Physics.SphereCast(rb.position, 0.51f, Vector3.down, out hitInfo, GetComponent<Collider2D>().bounds.size.y / 2, groundLayers);
		Debug.Log (isGrounded);
		isGrounded = Physics.Raycast(transform.position, Vector2.down, GetComponent<Collider2D>().bounds.size.y / 2);

		//transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		//adds gravity to the player
		rb.AddForce(Vector2.down * gravity * rb.mass);

		//
		//moves player right
		if (Input.GetButton(RIGHT) == true) 
		{
			//Debug.Log ("D pressed");
			transform.Translate(Vector2.right * horizSpeed  * Time.deltaTime);

		}

		//PLAYER INPUT
		//moves player left
		if (Input.GetButton (LEFT) == true) 
		{
			//Debug.Log ("A pressed");
			transform.Translate (Vector2.left * horizSpeed * Time.deltaTime);
		}

		//makes player jump
		if (Input.GetButton (JUMP) == true && isGrounded) 
		{
			rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
		}

		//makes player shoot
		if (Input.GetButton (SHOOT) == true) 
		{
			Debug.Log ("SPACE pressed");
			//create code to release a bullet - create class for it
		}
	}
}
