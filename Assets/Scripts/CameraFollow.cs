using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // the object to follow
    public float smoothing = 5f;    // how quickly the camera should move towards the target

    Vector3 offset;    // the initial offset between the camera and the target

    void Start()
    {
        // calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // calculate the new position for the camera to move towards
        Vector3 targetCamPos = target.position + offset;

        // move the camera towards the target position using smoothing
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
