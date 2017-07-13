using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public GameObject dean;

	private Rigidbody2D rb;
	private Transform ts;

	public float speed;
	private bool direction;
	private Vector3 force;
	private Vector3 startPos;
	private Vector3 currPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		ts = GetComponent<Transform>();

		startPos = ts.position;
		//Debug.Log(dean.GetComponentInParent<DeanScript>().getDirection());
	}

	// Update is called once per frame
	void Update () {
		move();
		currPos = ts.position;
		//Debug.Log("bullet start: " + startPos.x + " bullet curr: " + currPos.x);

		if (Mathf.Abs(currPos.x - startPos.x) > 5) 
		{
			Destroy (this.gameObject);
		}


		

	}

	public void setBulletVariables(bool d, Vector3 f) {
		direction = d;
		force = f;
	}

	void move() {
		//rb.velocity = speed * force;
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
