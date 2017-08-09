using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	private float gameTicks;
	private Transform ts;
	private Rigidbody2D rb;

	public float platformSpeed;
	public float leftBoundary;
	public float rightBoundary;
	private bool direction;

	private Vector3 leftVector;
	private Vector3 rightVector;
	private float currSpeed;	//current speed of platform

	// Use this for initialization
	void Start () {
		ts = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		gameTicks += Time.deltaTime;
		movePlatform ();
		
	}

	//moves platform left and right
	void movePlatform() 
	{
		//if the platform is moving right and it has not gone to the right boundary
		if (direction && (this.ts.transform.position.x < rightBoundary)) 
		{
			this.ts.Translate (Vector2.right * platformSpeed * Time.deltaTime);
			currSpeed = platformSpeed;
			//platform changes direction to left
			if (direction && this.transform.position.x >= rightBoundary) 
			{
				direction = false;
			}
		} 

		//if the platform is moving left and it has not gone to the left boundary
		if (!direction && (this.ts.transform.position.x > leftBoundary)) 
		{
			this.ts.Translate (Vector2.left * platformSpeed * Time.deltaTime);
			currSpeed = -platformSpeed;
			if (!direction && this.transform.position.x <= leftBoundary) 
			{
				direction = true;
			}
		}
	}


	public float getPlatformSpeed() 
	{
		return currSpeed;
	}
}
