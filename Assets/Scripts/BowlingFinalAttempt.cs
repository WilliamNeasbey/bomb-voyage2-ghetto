using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlingFinalAttempt : MonoBehaviour
{
    public float ballSpeed = 10f;
    public int maxThrowAttempts = 2;
    public int currentThrowAttempts = 0;
    public GameObject[] pins;
    public GameObject throwButton;
    public GameObject resetButton;
    public TextMeshProUGUI scoreText;

    private Vector3 ballStartPosition;
    private Rigidbody ballRigidbody;
    private bool ballThrown = false;

    void Start()
    {
        ballStartPosition = transform.position;
        ballRigidbody = GetComponent<Rigidbody>();
        resetGame();
    }

    void Update()
    {
        if (!ballThrown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballThrown = true;
                throwBall();
            }
        }
    }

    void throwBall()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.useGravity = true;
        ballRigidbody.AddForce(new Vector3(0, 0, ballSpeed), ForceMode.Impulse);
    }

    void resetGame()
    {
        currentThrowAttempts = 0;
        ballThrown = false;
        resetButton.SetActive(false);
        throwButton.SetActive(true);
        scoreText.text = "Score: 0";
        foreach (GameObject pin in pins)
        {
            pin.SetActive(true);
        }
        transform.position = ballStartPosition;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.useGravity = false;
    }
}
