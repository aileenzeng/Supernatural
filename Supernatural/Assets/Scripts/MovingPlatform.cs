using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	private float gameTicks;
	private Transform ts;

	public float platformSpeed;
	public float leftBoundary;
	public float rightBoundary;
	private bool direction;

	private Vector3 leftVector;
	private Vector3 rightVector;
	private Vector3 currVector;

	// Use this for initialization
	void Start () {
		direction = true;
	}
	
	// Update is called once per frame
	void Update () {
		ts = GetComponent<Transform> ();
		gameTicks += Time.deltaTime;
		movePlatform ();

		leftVector = (Vector2.left * platformSpeed * Time.deltaTime);
		rightVector = (Vector2.right * platformSpeed * Time.deltaTime);
		
	}

	//moves platform left and right
	void movePlatform() 
	{
		//if the platform is moving right and it has not gone to the right boundary

		if (direction && (this.ts.transform.position.x < rightBoundary)) 
		{
			//this.ts.Translate (Vector2.right * platformSpeed * Time.deltaTime);
			this.ts.Translate (rightVector);
			currVector = rightVector;
			//platform changes direction to left
			if (direction && this.transform.position.x >= rightBoundary) 
			{
				direction = false;
			}
		} 

		//if the platform is moving left and it has not gone to the left boundary
		if (!direction && (this.ts.transform.position.x > leftBoundary)) 
		{
			//this.ts.Translate (Vector2.left * platformSpeed * Time.deltaTime);
			this.ts.Translate (leftVector);
			currVector = leftVector;
			//platform changes direction to right
			if (!direction && this.transform.position.x <= leftBoundary) 
			{
				direction = true;
			}
		}
	}

	public Vector3 platformVector() 
	{
		return currVector;
	}
}
