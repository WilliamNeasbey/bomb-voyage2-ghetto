using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    [SerializeField] private float minPower = 10f;
    [SerializeField] private float maxPower = 25f;
    [SerializeField] private float powerIncreaseRate = 1f;
    [SerializeField] private float minAngle = 30f;
    [SerializeField] private float maxAngle = 150f;
    [SerializeField] private float angleIncreaseRate = 10f;

    private float currentPower;
    private float currentAngle;

    private bool isMoving = false;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (!isMoving && Input.GetKeyDown(KeyCode.Space))
        {
            // Start charging power and angle
            currentPower = minPower;
            currentAngle = minAngle;
            isMoving = true;
        }

        if (isMoving)
        {
            // Increase power and angle while space is held down
            if (Input.GetKey(KeyCode.Space))
            {
                currentPower += powerIncreaseRate * Time.deltaTime;
                currentAngle += angleIncreaseRate * Time.deltaTime;
                currentPower = Mathf.Clamp(currentPower, minPower, maxPower);
                currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
            }

            // Launch ball when space is released
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.useGravity = true;
                Vector3 force = Quaternion.Euler(currentAngle, 0f, 0f) * transform.forward * currentPower;
                rb.AddForce(force, ForceMode.Impulse);
                isMoving = false;
            }
        }
    }

    public void Reset()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        isMoving = false;
    }

}
