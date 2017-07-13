using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Allows to set a target for the camera to follow
	public GameObject targetObject;

	//Set private variable for car distance to camera
	private float distanceToTarget;

	// Use this for initialization
	void Start () {

		// calculate camera offset 
		distanceToTarget = transform.position.x - targetObject.transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {

		// Apply carsprite distance to camera offset
		float targetObjectX = targetObject.transform.position.x;

		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		transform.position = newCameraPosition;
	}
}
