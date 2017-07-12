using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//flips dean's sprite
public class DeanFlipScript : MonoBehaviour {

	public SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		sr.flipX = !GetComponentInParent<DeanScript>().getDirection();
		
	}
}
