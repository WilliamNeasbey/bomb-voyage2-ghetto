using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BowlingGame : MonoBehaviour
{
    /*public GameObject ballPrefab;           // Prefab for the bowling ball
    public Transform ballSpawnPoint;        // Transform of where the ball should be spawned
    public PinResetter pinResetter;         // Reference to the PinResetter script
    public float ballSpeed = 10f;           // Speed at which the ball should be thrown
    public float maxAngle = 20f;            // Maximum angle at which the ball can be thrown
    public float minAngle = -20f;           // Minimum angle at which the ball can be thrown
    public float aiDifficulty = 1f;         // Difficulty level of the AI (0 = easy, 1 = hard)
    public float aiDelay = 1f;              // Delay before the AI takes its turn
    public Text scoreText;                  // Text component to display the score
    

    private GameObject ball;                // Reference to the current bowling ball
   // private bool isPlayerTurn = true;       // Is it currently the player's turn?
    private bool isGameOver = false;        // Is the game over?
   // private int score = 0;                  // Current score

    public TextMeshProUGUI scoreText;   // Reference to the score text UI element
    public int score = 0;               // Current score
    public bool isPlayerTurn = true;    // Is it currently the player's turn?

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        // If it's the player's turn and they press the space bar, throw the ball
        if (isPlayerTurn && Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBall(Random.Range(minAngle, maxAngle));
        }
    }

    void ThrowBall(float angle)
    {
        ball = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(ballSpawnPoint.forward * ballSpeed + ballSpawnPoint.up * angle, ForceMode.Impulse);

        // Switch to the AI's turn after the ball has been thrown
        isPlayerTurn = false;
        StartCoroutine(DoAiTurn());
    }

    IEnumerator DoAiTurn()
    {
        // Wait for the specified delay before the AI takes its turn
        yield return new WaitForSeconds(aiDelay);

        // Calculate the difficulty-adjusted angle for the AI's throw
        float angle = Random.Range(minAngle, maxAngle) + (1f - aiDifficulty) * CalculateAngleOffset();

        ThrowBall(angle);
    }

    float CalculateAngleOffset()
    {
        // Calculate the angle offset based on the position of the pins
        float offset = 0f;

        foreach (Transform pin in pinResetter.pins.transform)
        {
            offset += Mathf.Abs(Vector3.Dot(pin.right, Vector3.up));
        }

        return offset / pinResetter.pins.transform.childCount;
    }

    public void AddScore(int pins)
    {
        score += pins;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
    
    public void EndTurn()
    {
        if (isPlayerTurn)
        {
            isPlayerTurn = false;
            FindObjectOfType<PinSetter>().PinsHaveSettled();
        }
        else
        {
            isPlayerTurn = true;
            FindObjectOfType<PinResetter>().ResetPins();
        }
    }*/
}
