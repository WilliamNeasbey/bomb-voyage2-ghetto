using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HuntGame : MonoBehaviour
{
    public GameObject[] targets; // an array of target prefabs to choose from
    public float gameTime = 30f; // the total length of the game in seconds
    public Text scoreText; // the text object that displays the score
    public Text timerText; // the text object that displays the time remaining
    public GameObject resultsScreen; // the results screen object that appears at the end of the game
    public Text finalScoreText; // the text object that displays the final score
    public Button returnToMenuButton; // the button to return to the menu
    public AudioClip gameMusic; // the music that plays during the game
    public AudioClip resultsMusic; // the music that plays at the end of the game
    public AudioSource audioSource; // the audio source component that plays the music
    public float startingTime = 30f;

    private int score = 0; // the player's current score
    private float timeRemaining; // the time remaining in the game
    private bool gameStarted = false; // whether the game has started yet
    private int scorePenalty = 10; // the penalty for clicking the wrong target

    void Start()
    {
        timeRemaining = gameTime;
        timerText.text = "Time: " + timeRemaining.ToString("F1");
        resultsScreen.SetActive(false);
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (gameStarted)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + timeRemaining.ToString("F1");
            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        gameStarted = false;
        audioSource.Stop();
        audioSource.clip = resultsMusic;
        audioSource.loop = false;
        audioSource.Play();
        resultsScreen.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
    }

    IEnumerator GenerateTarget()
    {
        int numTargetsSpawned = 0;
        while (gameStarted)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f)); // wait for a random amount of time
            Vector3 position = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f), 0); // generate a random position for the target
            GameObject newTarget = Instantiate(targets[Random.Range(0, targets.Length)], position, Quaternion.identity); // create the target
            newTarget.GetComponent<Button>().onClick.AddListener(() => HandleClick(newTarget)); // add a listener to handle the click event
            newTarget.tag = Random.Range(0, 2) == 0 ? "RightTarget" : "WrongTarget"; // set the target tag randomly
            score -= scorePenalty; // subtract score for missing the target
            UpdateScoreText();

            if (newTarget.tag == "RightTarget")
            {
                numTargetsSpawned++;
                if (numTargetsSpawned % 2 == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Vector3 newPos = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f), 0); // generate a random position for the new targets
                        GameObject additionalTarget = Instantiate(targets[Random.Range(0, targets.Length)], newPos, Quaternion.identity); // create the additional targets
                        additionalTarget.GetComponent<Button>().onClick.AddListener(() => HandleClick(additionalTarget)); // add a listener to handle the click event
                        additionalTarget.tag = "RightTarget"; // set the tag to "RightTarget"
                    }
                }
                score += 1; // add score for hitting the target
                UpdateScoreText();
                timeRemaining += 5f; // add time for hitting the target
                timerText.text = "Time: " + timeRemaining.ToString("F1");
            }
            else
            {
                timeRemaining -= 10f; // subtract time for missing the target
                timerText.text = "Time: " + timeRemaining.ToString("F1");
            }
        }
    }

    void HandleClick(GameObject target)
    {
        if (target.tag == "RightTarget")
        {
            score += 1;
            UpdateScoreText();
            timeRemaining += 5f;
            timerText.text = "Time: " + timeRemaining.ToString("F1");
            Destroy(target);
        }
        else
        {
            timeRemaining -= 10f;
            timerText.text = "Time: " + timeRemaining.ToString("F1");
            Destroy(target);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void StartGame()
    {
        audioSource.Stop();
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
        timeRemaining = startingTime;
        score = 0;
        gameStarted = true;
        resultsScreen.SetActive(false);
        UpdateScoreText();
        StartCoroutine(GenerateTarget());
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
