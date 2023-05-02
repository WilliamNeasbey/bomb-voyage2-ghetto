using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerMinecraftParkour : MonoBehaviour
{
    public float countdownTime = 45f; // the time to countdown from
    public TMP_Text timerText; // the UI text element to display the countdown
    public TMP_Text bestTimeText; // the UI text element to display the best time
    public string nextSceneName; // the name of the next scene to load if the player collides with the finish line
    public string gameOverSceneName; // the name of the game over scene to load if the player doesn't collide with the finish line

    public BoxCollider2D endTrigger; // reference to the 2D box collider for the finish line
    public string playerTag = "Player"; // tag of the player object

    private float currentTime; // the current time left in the countdown
    private float bestTime = Mathf.Infinity; // the best time, initially set to infinity

    private bool isCountingDown = false; // whether the timer is currently counting down
    private bool hasReachedFinish = false; // whether the player has collided with the finish line

    void Start()
    {
        // try to load the best time from player preferences
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
        }

        // display the best time
        bestTimeText.text = "Best Time: " + FormatTime(bestTime);
    }

    void Update()
    {
        if (isCountingDown)
        {
            // update the current time and display it
            currentTime -= Time.deltaTime;
            timerText.text = "Time Left: " + FormatTime(currentTime);

            // check if the countdown is complete
            if (currentTime <= 0f)
            {
                EndCountdown();
            }
        }
        else
        {
            StartCountdown(); // start the countdown if it hasn't already started
        }
    }

    public void StartCountdown()
    {
        // reset the current time and start counting down
        currentTime = countdownTime;
        isCountingDown = true;
        hasReachedFinish = false;
    }

    public void EndCountdown()
    {
        // stop counting down and check if the current time is the new best time
        isCountingDown = false;
        if (currentTime < bestTime && hasReachedFinish)
        {
            bestTime = currentTime;
            bestTimeText.text = "Best Time: " + FormatTime(bestTime);
            // save the new best time to player preferences
            PlayerPrefs.SetFloat("BestTime", bestTime);
            // load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // load the game over scene
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called with collider: " + other.name);
        // check if the other collider has the player tag and is the finish line trigger
        if (other.CompareTag(playerTag) && other == endTrigger)
        {
            hasReachedFinish = true;
            
        }
    }

    private string FormatTime(float time)
    {
        // format the time as MM:SS
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
