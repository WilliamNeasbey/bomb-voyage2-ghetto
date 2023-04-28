using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    public float stopTime = 1f; // The amount of time the object needs to be stopped to enable the UI
    public float startDelay = 10f; // The delay before the check starts
    public GameObject uiObject; // The UI object that needs to be enabled

    private Rigidbody rb;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = stopTime;
        StartCoroutine(CheckStopped()); // Start the coroutine
    }

    IEnumerator CheckStopped()
    {
        yield return new WaitForSeconds(startDelay); // Wait for the delay
        while (true) // Loop forever
        {
            if (rb.velocity.magnitude < 0.01f) // Check if the object has stopped moving
            {
                timer -= Time.deltaTime;
                if (timer <= 0) // If the object has been stopped for the specified amount of time
                {
                    uiObject.SetActive(true); // Enable the UI object
                    yield break; // Exit the coroutine
                }
            }
            else
            {
                timer = stopTime; // Reset the timer if the object is still moving
            }
            yield return null; // Wait until the next frame
        }
    }
}
