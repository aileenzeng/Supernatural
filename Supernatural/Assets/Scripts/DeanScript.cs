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
	private Rigidbody rb;
	public float horizSpeed;
	public float jumpSpeed;
	public float gravity;
	public LayerMask groundLayers;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameTicks += Time.deltaTime;
		movePlayer ();

	}

	//Controls player movement
	void movePlayer() {

		//moves player right
		if (Input.GetButton(RIGHT) == true) 
		{
			Debug.Log ("D pressed");
			transform.Translate(Vector2.right * horizSpeed  * Time.deltaTime);

		}

		//moves player left
		if (Input.GetButton (LEFT) == true) 
		{
			Debug.Log ("A pressed");
			transform.Translate (Vector2.left * horizSpeed * Time.deltaTime);
		}

		//makes player jump
		if (Input.GetButton (JUMP) == true) 
		{
			Debug.Log ("W pressed");
			//rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
		}

		//makes player shoot
		if (Input.GetButton (SHOOT) == true) 
		{
			Debug.Log ("SPACE pressed");
			//create code to release a bullet - create class for it
		}
		//Tell if there is anything in a sphere shape below the player
		//RaycastHit hitInfo;
		//isGrounded = Physics.SphereCast(rb.position, 0.75f, Vector3.down, out hitInfo, GetComponent<Collider>().bounds.size.y / 2, groundLayers);
		//rb.AddForce(Vector2.down * gravity * rb.mass);
	}
}
