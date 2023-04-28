using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTest : MonoBehaviour
{
    public Transform playerTransform; // Reference to player's transform
    public Transform groundTransform; // Reference to ground's transform
    public float startingGroundSpeed = 5f; // Starting speed of the ground
    public float respawnDistance = 50f; // Distance after which the ground should respawn
    public float speedIncreaseRate = 0.1f; // Rate at which the speed increases
    public float maxGroundSpeed = 20f; // Maximum speed the ground can reach

    private float groundWidth; // Width of the ground
    private float currentGroundSpeed; // Current speed of the ground

    void Start()
    {
        // Get the width of the ground
        groundWidth = groundTransform.GetComponent<Renderer>().bounds.size.x;

        // Initialize the ground speed
        currentGroundSpeed = startingGroundSpeed;
    }

    void Update()
    {
        // Move the ground to the left at the current speed
        groundTransform.Translate(Vector3.left * currentGroundSpeed * Time.deltaTime);

        // If the ground has moved too far to the left, respawn it to the right
        if (playerTransform.position.x - groundTransform.position.x > respawnDistance)
        {
            Vector3 newPos = new Vector3(groundTransform.position.x + groundWidth,
                                         groundTransform.position.y,
                                         groundTransform.position.z);
            groundTransform.position = newPos;
        }

        // Gradually increase the ground speed over time
        currentGroundSpeed = Mathf.Min(maxGroundSpeed, currentGroundSpeed + speedIncreaseRate * Time.deltaTime);
    }
}
