using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRoam : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the object moves
    public float roamRadius = 10f; // The maximum distance the object can roam from its starting position
    public float roamInterval = 2f; // The time interval between each roam direction change
    public bool isRoaming = true; // Whether the object is currently roaming or not
    public LayerMask groundLayer; // The layer where the ground objects are placed
    public float groundCheckDistance = 1f; // The distance from the object to check for the ground
    public float stopRoamingTimeMin = 3f; // The minimum time the object stops roaming after reaching its desired location
    public float stopRoamingTimeMax = 5f; // The maximum time the object stops roaming after reaching its desired location

    private Vector3 startingPosition; // The position where the object starts roaming
    private Vector3 roamDirection; // The direction in which the object is currently roaming
    private float roamTimer = 0f; // A timer to keep track of when the object should change roam direction
    private bool isMoving = true; // Whether the object is currently moving or not
    private float stopRoamingTime = 0f; // The time to stop roaming

    void Start()
    {
        startingPosition = transform.position;
        ChooseRoamDirection();
    }

    void Update()
    {
        if (isRoaming)
        {
            if (isMoving)
            {
                // Move the object in the current roam direction
                transform.position += roamDirection * moveSpeed * Time.deltaTime;

                // Check if the object is about to hit an obstacle or fall off the ground, and if so, choose a new roam direction
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
                {
                    ChooseRoamDirection();
                }
                else if (Physics.Raycast(transform.position, roamDirection, out hit, roamRadius))
                {
                    ChooseRoamDirection();
                }

                // Update the roam timer and choose a new roam direction if the timer has expired
                roamTimer -= Time.deltaTime;
                if (roamTimer <= 0)
                {
                    ChooseRoamDirection();
                }

                // Rotate the object to face the direction it's moving in
                if (roamDirection.magnitude > 0)
                {
                    transform.rotation = Quaternion.LookRotation(roamDirection, Vector3.up);
                }

                // Check if the object has reached its desired location, and if so, stop moving and set the stopRoamingTime
                if (Vector3.Distance(transform.position, startingPosition) > roamRadius)
                {
                    isMoving = false;
                    stopRoamingTime = Time.time + Random.Range(stopRoamingTimeMin, stopRoamingTimeMax);
                }
            }
            else
            {
                // Stop moving and wait for the stopRoamingTime to expire
                if (Time.time >= stopRoamingTime)
                {
                    isMoving = true;
                    ChooseRoamDirection();
                }
            }
        }
    }

    void ChooseRoamDirection()
    {
        // Choose a new random direction
        roamDirection = Random.insideUnitSphere.normalized * roamRadius;
        // Make sure the object isn't pointing directly at an obstacle or off the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, roamDirection, out hit, roamRadius))
        {
            roamDirection = Vector3.Reflect(roamDirection, hit.normal);
        }
        else if (!Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            roamDirection = Vector3.Reflect(roamDirection, Vector3.up);
        }

        // Reset the roam timer
        roamTimer = roamInterval;
    }
}
