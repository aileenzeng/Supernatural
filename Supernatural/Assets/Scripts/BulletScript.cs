using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public GameObject player;

	private Rigidbody2D rb;
	private Transform ts;

	public float speed;
	private bool direction;
	private Vector3 force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		direction = GetComponentInParent<DeanScript> ().getDirection ();
	}

	// Update is called once per frame
	void Update () {
		moveBullet ();

	}

	void moveBullet() {
		rb.velocity = speed * force;
	}

	void setForce() {
		if (direction) {
			force = Vector2.right;
		}

		if (!direction) {
			force = Vector2.left;
		}
	}

		
}
