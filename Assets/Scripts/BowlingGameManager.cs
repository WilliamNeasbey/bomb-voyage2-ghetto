using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BowlingGameManager : MonoBehaviour
{
  /*  [SerializeField] private BowlingBallController bowlingBall;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI aiScoreText;
    [SerializeField] private int maxFrames = 10;
    [SerializeField] private int maxPins = 10;
    [SerializeField] private float aiDifficulty = 0.75f;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private int currentPlayerScore = 0;
    private int currentAiScore = 0;
    private int currentFrame = 1;
    private int currentPins = 10;

    private bool isPlayerTurn = true;
    private bool isGameOver = false;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (!isGameOver && !bowlingBall.IsMoving())
        {
            if (isPlayerTurn)
            {
                currentPlayerScore += maxPins - currentPins;
                isPlayerTurn = false;
                currentPins = 10;
            }
            else
            {
                currentAiScore += Mathf.RoundToInt(Random.Range(currentPins * aiDifficulty, currentPins));
                isPlayerTurn = true;
                currentPins = 10;
                currentFrame++;

                if (currentFrame > maxFrames)
                {
                    isGameOver = true;
                    EndGame();
                }
            }

            UpdateUI();
            bowlingBall.Reset();
        }
    }

    private void UpdateUI()
    {
        playerScoreText.text = "Player: " + currentPlayerScore;
        aiScoreText.text = "AI: " + currentAiScore;
    }

    private void EndGame()
    {
        if (currentPlayerScore > currentAiScore)
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (currentPlayerScore < currentAiScore)
        {
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            SceneManager.LoadScene("TieScene");
        }
    }*/
}
