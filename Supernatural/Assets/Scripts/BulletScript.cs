using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public DeanScript dean;

	private Rigidbody2D rb;
	private Transform ts;

	public float speed;
	private bool direction;
	private Vector3 force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}


		
}
