using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//flips demon sprites
public class DemonFlipScript : MonoBehaviour {

	public SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		sr.flipX = GetComponentInParent<DemonScript>().getDirection();
	}
}
