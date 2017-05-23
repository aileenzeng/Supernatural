using System.Collections;
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

	// Use this for initialization
	void Start () {
		direction = true;
		gameTicks = 0.0f;

		rb = GetComponent<Rigidbody2D> ();
		ts = GetComponent<Transform> (); 

		rb.freezeRotation = true;

	}

	// Update is called once per frame
	void Update () {
		gameTicks += Time.deltaTime;

		moveDemon();
		
	}

	//moves demon left and right
	void moveDemon() {
		//if the demon is moving right and it has not gone to the right boundary
		if (direction && (this.ts.transform.position.x < rightBoundary)) 
		{
			this.ts.Translate (Vector2.right * DemonSpeed * Time.deltaTime);
			Debug.Log ("Enemy is moving right");
			if (this.transform.position.x == rightBoundary) {
				direction = !direction;
				Debug.Log ("changing direction");
			}
		} 
		//if the demon is moving left and it has not gone to the left boundary
		else if (!direction && (this.ts.transform.position.x > leftBoundary)) 
		{
			this.ts.Translate (Vector2.left * DemonSpeed * Time.deltaTime);
			direction = !direction;
			if (this.transform.position.x == leftBoundary) {
				direction = !direction;
				Debug.Log ("Changing direction");
			}
			Debug.Log ("Demon is moving left");
		}

	}

	public void kill() {
		Destroy (this.gameObject);
	}
}
