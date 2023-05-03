using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RockPaperScissors : MonoBehaviour
{
    public Text resultText;

    private int playerChoice;
    private int computerChoice;

    public TextMeshProUGUI P1Wins;
    public int Player1Wins;

    public TextMeshProUGUI P2Wins;
    public int Player2Wins;

    void Start()
    {
        resultText.text = "Choose Rock, Paper, or Scissors";
        //P1Wins = GetComponent<TextMeshProUGUI>();
        Player1Wins = 0;
        Player2Wins = 0;
    }

    public void ChooseRock()
    {
        playerChoice = 0;
        PlayGame();
    }

    public void ChoosePaper()
    {
        playerChoice = 1;
        PlayGame();
    }

    public void ChooseScissors()
    {
        playerChoice = 2;
        PlayGame();
    }

    private void PlayGame()
    {
        computerChoice = Random.Range(0, 3);
        string[] choices = { "Rock", "Paper", "Scissors" };
        string result;

        if (playerChoice == computerChoice)
        {
            result = "It's a tie!";
        }
        else if ((playerChoice == 0 && computerChoice == 2) ||
                 (playerChoice == 1 && computerChoice == 0) ||
                 (playerChoice == 2 && computerChoice == 1))
        {
            result = "You win!";
            P1Wins.text = Player1Wins.ToString();
            Player1Wins++;
        }
        else
        {
            result = "The King of the court Alex Kidd chose wins!";
            P2Wins.text = Player2Wins.ToString();
            Player2Wins++;
        }

        resultText.text = "You chose " + choices[playerChoice] + ", The King of the court Alex Kidd chose " + choices[computerChoice] + ". " + result;
    }

    private void Update()
    {
        if (Player1Wins >= 25)
        {
            SceneManager.LoadScene("AlexKiddWin");
        }
        if (Player2Wins >= 25)
        {
            SceneManager.LoadScene("AlexKiddLose");
        }
    }
}
