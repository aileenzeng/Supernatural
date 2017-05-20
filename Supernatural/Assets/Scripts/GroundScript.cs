using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {
	private DeanScript dean;
	// Use this for initialization
	void Start () {
		dean = GetComponentInParent<DeanScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
