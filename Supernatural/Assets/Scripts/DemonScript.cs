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

	}

	public void kill() {
		Destroy (this.gameObject);
	}
}
