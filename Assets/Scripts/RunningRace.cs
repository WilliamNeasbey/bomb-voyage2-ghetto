using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRace : MonoBehaviour
{
    public float buttonMashSpeed = 50f;  // The speed at which the player accelerates when mashing the button
    public float buttonMashDuration = 3f;  // The duration of the button mash mechanic in seconds
    public KeyCode runButton = KeyCode.Space;  // The button to mash to make the player run
    public Animator animator;  // The animator component that controls the player's animation
    public GameObject[] opponents;  // The AI opponents in the race
    public float raceDistance = 100f;  // The distance of the race in meters
    public GameObject winnerPodium;  // The game object representing the winner's podium
    public GameObject[] podiumPositions;  // The positions of the podiums in order from first to third

    private float currentSpeed = 0f;  // The player's current speed
    private float buttonMashTimer = 0f;  // Timer for the button mash mechanic
    private bool hasWon = false;  // Flag indicating whether the player has won the race
    private int[] positions;  // The positions of each character in the race

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the positions array to all be zero
        positions = new int[opponents.Length + 1];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            // The player has won, stop updating the game
            return;
        }

        // Check if the player is mashing the button
        if (Input.GetKey(runButton) && buttonMashTimer < buttonMashDuration)
        {
            // Accelerate the player's speed when mashing the button
            currentSpeed += buttonMashSpeed * Time.deltaTime;
            buttonMashTimer += Time.deltaTime;
        }

        // Update the player's position based on their current speed
        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        // Update the player's animation based on their current speed
        if (animator != null)
        {
            animator.SetFloat("Speed", currentSpeed);
        }

        // Decelerate the player's speed over time
        currentSpeed -= currentSpeed * Time.deltaTime;

        // Check if the player has crossed the finish line
        if (transform.position.z >= raceDistance)
        {
            hasWon = true;
            positions[0] = 1;  // The player has finished in first place
            Debug.Log("You won the race!");
        }

        // Update the AI opponents' positions
        for (int i = 0; i < opponents.Length; i++)
        {
            GameObject opponent = opponents[i];
            float opponentSpeed = Random.Range(10f, 20f);  // The AI opponent's speed (randomly chosen)
            opponent.transform.position += opponent.transform.forward * opponentSpeed * Time.deltaTime;
            if (opponent.transform.position.z >= raceDistance)
            {
                hasWon = true;
                positions[i + 1] = 1;  // The opponent has finished in ith place
                Debug.Log("An opponent won the race.");
            }
        }
        // Check if all characters have finished the race
        if (hasWon)
        {
            // Calculate the positions of each character in the race
            for (int i = 0; i < positions.Length; i++)
            {
                int numAhead = 0;
                for (int j = 0; j < positions.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (positions[j] > positions[i])
                    {
                        numAhead++;
                    }
                }
                positions[i] += numAhead;
            }

            // Place each character on the winner's podium based on their position
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] == 0)
                {
                    // The character did not finish the race
                    continue;
                }
                GameObject character = null;
                if (i == 0)
                {
                    // The player finished in first place
                    character = gameObject;
                }
                else
                {
                    // An AI opponent finished in ith place
                    character = opponents[i - 1];
                }
                // Place the character on the appropriate position on the winner's podium
                character.transform.position = podiumPositions[positions[i] - 1].transform.position;
            }

            // Show the winner's podium
            winnerPodium.SetActive(true);
        }
    }
}
