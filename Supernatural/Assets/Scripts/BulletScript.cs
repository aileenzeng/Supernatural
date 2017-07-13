using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public GameObject dean;

	private Transform ts;

	public float speed;
	private Vector3 startPos;
	private Vector3 currPos;

	// Use this for initialization
	void Start () {
		ts = GetComponent<Transform>();
		startPos = ts.position;
	}

	// Update is called once per frame
	void Update () {
		currPos = ts.position;

		//Destroys bullet after it has traveled a certain distance
		if (Mathf.Abs(currPos.x - startPos.x) > 5) 
		{
			Destroy (this.gameObject);
		}


		

	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Demon") 
		{
			Destroy (this.gameObject);
		}

		if (col.gameObject.tag == "Win") 
		{
			Destroy (this.gameObject);
		}
	}


		
}
