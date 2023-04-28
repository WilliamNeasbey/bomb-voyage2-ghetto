using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeRunContest : MonoBehaviour
{
    public GameObject target;
    public float timeLimit = 10f;
    public float maxPower = 10f;
    public float minPower = 5f;

    private float timeRemaining;
    private bool isPlaying = false;
    private bool isHit = false;
    private float hitDistance = 0f;
    private Rigidbody targetRigidbody;
    private float power = 0f;

    public Text timeText;
    public Text distanceText;

    
    void Start()
    {
        timeRemaining = timeLimit;
        targetRigidbody = target.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isPlaying)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = "Time: " + timeRemaining.ToString("F1");

            if (timeRemaining <= 0f)
            {
                isPlaying = false;
                CalculateHitDistance();
            }
        }

        if (isHit)
        {
            distanceText.text = "Distance: " + hitDistance.ToString("F1");
        }
    }

    void CalculateHitDistance()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        hitDistance = distance;
        isHit = true;
    }

    public void StartGame()
    {
        isPlaying = true;
        isHit = false;
        timeRemaining = timeLimit;
        power = Random.Range(minPower, maxPower);
        targetRigidbody.velocity = Vector3.zero;
        targetRigidbody.angularVelocity = Vector3.zero;
        target.transform.position = new Vector3(0f, 0f, 0f);
        target.transform.rotation = Quaternion.identity;
    }

    public void Hit()
    {
        if (!isPlaying)
        {
            return;
        }

        targetRigidbody.AddForce(transform.forward * power, ForceMode.Impulse);
        isPlaying = false;
    }
}
