using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    public float speed = 1.0f;  // The speed at which the object moves up and down
    public float distance = 1.0f;  // The distance the object moves up and down

    private Vector3 startPosition;  // The object's starting position

    void Start()
    {
        startPosition = transform.position;  // Set the starting position to the object's current position
    }

    void Update()
    {
        // Calculate the new y position based on the sine wave of time and speed
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * distance;

        // Set the object's position to the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
