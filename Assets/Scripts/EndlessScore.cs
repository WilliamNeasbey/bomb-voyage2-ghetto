using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessScore : MonoBehaviour
{
    public Transform playerTransform; // Reference to player's transform
    public Text scoreText; // Reference to UI text element

    private float distanceTraveled; // Distance the player has traveled

    void Start()
    {
        // Initialize the score text
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        // Update the distance traveled based on the player's movement
        distanceTraveled = playerTransform.position.x;

        // Update the score text with the current distance traveled
        scoreText.text = "Score: " + Mathf.FloorToInt(distanceTraveled).ToString();
    }
}
