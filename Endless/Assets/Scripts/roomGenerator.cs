using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomGenerator : MonoBehaviour {

	public GameObject[] availableRooms;

	public List<GameObject> currentRooms;

	private float screenWidthInPoints;

	// Use this for initialization
	void Start () {
		// Calculate size of screen in points
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddRoom(float farhtestRoomEndX)
	{
		// Pick random index of room to generate
		int randomRoomIndex = Random.Range(0, availableRooms.Length);

		// Creates room object from array of available rooms
		GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);

		// Takes the size of the RoomFloor (width of room) object
		float roomWidth = room.transform.Find("floor").localScale.x;

		// Sets point where new room should be added
		float roomCenter = farhtestRoomEndX + roomWidth * 0.5f;

		// Sets the X-coordinate of new room
		room.transform.position = new Vector3(roomCenter, 0, 0);

		// Adds the room to current list of rooms
		currentRooms.Add(room);         
	} 
}
