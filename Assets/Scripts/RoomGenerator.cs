using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab; // Prefab of the basic room template
    public int roomCount = 10; // Number of rooms to generate
    public float roomDistance = 10f; // Distance between each room
    public GameObject hallwayPrefab;

    private Vector3 currentPos;

    void Start()
    {
        currentPos = transform.position;
        GenerateRooms();
    }

    void GenerateRooms()
    {
        for (int i = 0; i < roomCount; i++)
        {
            // Create new room and position it
            GameObject newRoom = Instantiate(roomPrefab, currentPos, Quaternion.identity);
            currentPos += Vector3.right * roomDistance;

            // Connect to previous room (if not the first room)
            if (i > 0)
            {
                ConnectRooms(newRoom, i);
            }
        }
    }

    void ConnectRooms(GameObject newRoom, int roomIndex)
    {
        // Connect the new room to the previous room
        GameObject previousRoom = transform.GetChild(roomIndex - 1).gameObject;

        // Example connection: create a hallway between rooms
        Vector3 hallwayPos = (newRoom.transform.position + previousRoom.transform.position) / 2f;
        GameObject newHallway = Instantiate(hallwayPrefab, hallwayPos, Quaternion.identity);
    }
}
