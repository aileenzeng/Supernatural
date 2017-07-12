﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour {
	private float gameTicks; 

	private Rigidbody2D rb;
	private Transform ts; 

	public float DemonSpeed; 

	private bool direction; //right = true, left = false
	public float rightBoundary; //how far the demon goes right
	public float leftBoundary; //how far the demon goes left

	public int health;

	// Use this for initialization
	void Start () {
		direction = true;
		gameTicks = 0.0f;

		rb = GetComponent<Rigidbody2D> ();
		ts = GetComponent<Transform> (); 

		rb.freezeRotation = true;

	}

	// Update is called once per frame
	void Update () 
	{
		gameTicks += Time.deltaTime;

		moveDemon();
		if (health <= 0) 
		{
			kill ();
		}

		
	}

	//moves demon left and right
	void moveDemon() 
	{
		//Debug.Log ("Position: " + ts.transform.position.x + " Direction: " + direction);
		//if the demon is moving right and it has not gone to the right boundary
		if (direction && (this.ts.transform.position.x < rightBoundary)) 
		{
			this.ts.Translate (Vector2.right * DemonSpeed * Time.deltaTime);
			//enemy changes direction
			if (direction && this.transform.position.x >= rightBoundary) 
			{
				direction = false;
			}
		} 

		//if the demon is moving left and it has not gone to the left boundary
		if (!direction && (this.ts.transform.position.x > leftBoundary)) 
		{
			this.ts.Translate (Vector2.left * DemonSpeed * Time.deltaTime);
			//enemy changes direction
			if (!direction && this.transform.position.x <= leftBoundary) 
			{
				direction = true;
			}
		}

	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Bullet") 
		{
			health--;
		}
	}

	public void kill() 
	{
		Destroy (this.gameObject);
	}

	public bool getDirection() 
	{
		return direction;
	}
}
