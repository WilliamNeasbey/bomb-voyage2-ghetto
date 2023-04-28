using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortGame : MonoBehaviour
{
    // Public variables
    public int score = 0;
    public float timeLimit = 60.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject bombPrefab;
    public Transform leftGroup;
    public Transform rightGroup;

    // Private variables
    private float timeRemaining;
    private bool gameRunning;
    private List<GameObject> bombs;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize game variables
        timeRemaining = timeLimit;
        gameRunning = true;
        bombs = new List<GameObject>();

        // Start the game loop
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.RoundToInt(timeRemaining).ToString();

        // Check if the game is over
        if (timeRemaining <= 0.0f)
        {
            gameRunning = false;
            GameOver();
        }

        // Handle user input
        if (gameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Drop the bomb
                GameObject bomb = Instantiate(bombPrefab);
                bombs.Add(bomb);
            }

            if (Input.GetMouseButton(0))
            {
                // Move the bombs to the left group
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0.0f;
                foreach (GameObject bomb in bombs)
                {
                    if (bomb.transform.position.x < mousePos.x)
                    {
                        bomb.transform.SetParent(leftGroup);
                    }
                }
            }

            if (Input.GetMouseButton(1))
            {
                // Move the bombs to the right group
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0.0f;
                foreach (GameObject bomb in bombs)
                {
                    if (bomb.transform.position.x >= mousePos.x)
                    {
                        bomb.transform.SetParent(rightGroup);
                    }
                }
            }
        }
    }

    // Game loop coroutine
    IEnumerator GameLoop()
    {
        // Wait for a brief moment before starting the game
        yield return new WaitForSeconds(2.0f);

        // Main game loop
        while (gameRunning)
        {
            // Wait for a brief moment before spawning the next bomb
            yield return new WaitForSeconds(1.0f);

            // Update the score
            int leftCount = leftGroup.childCount;
            int rightCount = rightGroup.childCount;
            score = leftCount == rightCount ? score + 1 : score;

            // Update the score text
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Game over method
    void GameOver()
    {
        // Display the game over screen
        // Play the game over music
        // Add UI buttons to load other scenes
    }
}
