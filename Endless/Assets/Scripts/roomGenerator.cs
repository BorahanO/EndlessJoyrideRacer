using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roomGenerator : MonoBehaviour {

	public GameObject[] availableRooms;

	public List<GameObject> currentRooms;

	private float screenWidthInPoints;


	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {

		GenerateRoomIfRequred();
	}


	void AddRoom(float farhtestRoomEndX)
	{
		// Picks random index of room to generate
		int randomRoomIndex = Random.Range(0, availableRooms.Length);

		// Creates room object from array of available rooms
		GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);

		// Take the size of the floor equal to room size
		float roomWidth = room.transform.Find("Floor").localScale.x;

		// Sets the end of the room where the next one will spawn
		float roomCenter = farhtestRoomEndX + roomWidth * 0.5f;

		// Sets the x coordinate of the room
		room.transform.position = new Vector3(roomCenter, 0, 0);

		// Adds room to current list of rooms
		currentRooms.Add(room);			
	} 

	void GenerateRoomIfRequred()
	{
		// Creates list to store rooms that need to be removed
		List<GameObject> roomsToRemove = new List<GameObject>();

		// Shows if you need to add more rooms
		bool addRooms = true;        

		// Saves player position
		float playerX = transform.position.x;

		// Point after which room should be removed
		float removeRoomX = playerX - screenWidthInPoints;        

		// If there's no room after addRoomX, add a room
		float addRoomX = playerX + screenWidthInPoints;

		// Store point where level ends 
		float farhtestRoomEndX = 0;

		foreach(var room in currentRooms)
		{
			// Use floor to calculate room End & Startpoint
			float roomWidth = room.transform.Find("Floor").localScale.x;
			float roomStartX = room.transform.position.x - (roomWidth * 0.5f);    
			float roomEndX = roomStartX + roomWidth;                            

			// If there is a room after addRoomX dont add one ontop of that
			if (roomStartX > addRoomX)
				addRooms = false;

			// If room end left of removeRoomX, it's offscreen and needs to be removed
			if (roomEndX < removeRoomX)
				roomsToRemove.Add(room);

			// Right point of level where new room will be added
			farhtestRoomEndX = Mathf.Max(farhtestRoomEndX, roomEndX);
		}

		// Removes rooms marked for removal
		foreach(var room in roomsToRemove)
		{
			currentRooms.Remove(room);
			Destroy(room);            
		}

		// If there is no room and addRooms = true, a new room will be added
		if (addRooms)
			AddRoom(farhtestRoomEndX);
	}
}