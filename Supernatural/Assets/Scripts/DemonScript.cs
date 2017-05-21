using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour {
	private float gameTicks; 

	private Rigidbody2D rb;
	private Transform ts; 

	public float DemonSpeed; 

	// Use this for initialization
	void Start () {
		gameTicks = 0.0f;
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
}
