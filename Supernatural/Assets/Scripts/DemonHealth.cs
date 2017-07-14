using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHealth : MonoBehaviour {
	public GameObject demon;
	private int health;
	private string display;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		health = demon.GetComponentInParent<DemonScript> ().health;
		display = new string("Health: " + health);
	}

	public string displayHealth() 
	{
		return display;
	}
}
