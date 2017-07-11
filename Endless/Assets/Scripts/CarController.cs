using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public float jetpackForce = 75.0f;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () 
	{
		bool jetpackActive = (Input.GetKey ("space"));

		if (jetpackActive)
		{
			rb.AddForce(new Vector2(0, jetpackForce));
		}
	}
}
