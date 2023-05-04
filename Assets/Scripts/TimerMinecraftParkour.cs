using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerMinecraftParkour : MonoBehaviour
{
    public float countdownTime = 45f;
    public TextMeshProUGUI countdownDisplay;
    public TextMeshProUGUI bestTimeDisplay;

    private bool isCountingDown = false;
    private float currentTime = 0f;
    private float bestTime = 0f;
    private bool hasFinished = false;

    private void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        bestTimeDisplay.text = "Best Time: " + bestTime.ToString("0.00") + "s";
        StartCountdown();
    }

    private void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                EndCountdown();
            }
        }

        countdownDisplay.text = currentTime.ToString("0.00") + "s";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasFinished = true;
            EndCountdown();
        }
    }

    public void StartCountdown()
    {
        isCountingDown = true;
        currentTime = countdownTime;
        countdownDisplay.text = currentTime.ToString("0.00") + "s";
    }

    void EndCountdown()
    {
        // Stop the timer and update the best time if necessary
        isCountingDown = false;
        float elapsedTime = countdownTime - currentTime;
        if (elapsedTime < bestTime || bestTime == 0f)
        {
            bestTime = elapsedTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            bestTimeDisplay.text = "Best Time: " + bestTime.ToString("0.00") + "s";
        }

        // Load the appropriate scene based on whether the player reached the finish line
        if (hasFinished)
        {
            SceneManager.LoadScene("MinecraftWin");
        }
        else
        {
            SceneManager.LoadScene("MinecraftLose");
        }
    }
}
