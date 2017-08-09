using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public GameObject dean;	
	private bool direction; //right = true, left = false;

	private Transform ts;
	private Rigidbody2D rb;

	private Vector2 force;
	public float speed;

	private Vector3 startPos;
	private Vector3 currPos;

	// Use this for initialization
	void Start () {
		ts = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		startPos = ts.position;

		//direction = dean.GetComponent<DeanScript>().getDirection ();
		//Debug.Log ("BULLETSCRIPT DIRECTION: " + dean.GetComponent<DeanScript>().getDirection());

		if (direction) 
		{
			force = Vector2.right;
		} 

		if (!direction)
		{
			force = Vector2.left;		
		}
	}

	// Update is called once per frame
	void Update () {
		currPos = ts.position;
		rb.velocity = speed * force;

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

	public void setDirection(bool d) 
	{
		direction = d;
	}

		
}
