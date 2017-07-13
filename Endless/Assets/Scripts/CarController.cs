using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	// Variables public for easy In-Engine Edit
	// Speed of car movement
	public float Speed = 3.0f;
	// Power of jetpack
	public float jetpackForce = 75.0f;
	// Rigidbody for gravity
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
		//Jetpack controls
		bool jetpackActive = (Input.GetKey ("space"));

		if (jetpackActive)
		{
			rb.AddForce(new Vector2(0, jetpackForce));
		}
		//Automatic movement
		Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
		newVelocity.x = Speed;
		GetComponent<Rigidbody2D>().velocity = newVelocity;
	}
}
