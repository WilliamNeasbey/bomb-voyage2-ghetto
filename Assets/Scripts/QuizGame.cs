using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizGame : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons;
    public TMP_Text resultText;
    public GameObject quizPanel;
    public GameObject resultPanel;
    public GameObject Background;

    private string[,] questions = new string[10, 5] {
        { "Who was the lead NBA player featured in Space Jam: A New Legacy?", "LeBron James", "Steve Harvey", "kobe bryant", "Giannis Antetokounmpo" },
        { "How many times has Booker T won the WCW World Heavyweight Championship?", "5 times", "4 times", "6 times", "3 times" },
        { "What year was travis scott added to fortnite?", "2020", "2019", "2021", "2018" },
        { "Why was Bill Cosby sent to prison in 2018?", "Drugging and sexually assaulting a woman", "Cheating in a call of duty tournament", "Attempted murder", "Intentional vehicular manslaughter" },
        { "What video game did Mike Tyson appear in?", "Nintendo Punch out", "WWE 2k11", "Fortnite", "One Punch Man: A Hero Nobody Knows" },
        { "What year did the best dragon ball film Dragonball Evolution realease?", "2009", "2007", "2008", "2006" },
        { "What was Soulja Boy's first song?", "Crank That", "Kiss Me Thru the Phone", "Booty Meat", "California Gurls" },
        { "Who was involved in a helicopter crash in 2020?", "Kobe Bryant", "Snoop Dogg", "Barack Obama", "Will Smith" },
        { "Who voiced Oscar in the hit dreamworks movie Sharktale?", "Will Smith", "Micheal Jordan", "kevin hart", "Chris Rock" },
        { "How tall is Snoop Dogg?", "6 feet 4 inches", "5 feet 11 inches", "6 feet 1 inches", "5 feet 3 inches" }
    };

    private int questionIndex = 0;
    private int correctAnswers = 0;

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        // Get the question and answers from the questions array
        string question = questions[questionIndex, 0];
        string[] answers = new string[4];
        for (int i = 1; i <= 4; i++)
        {
            answers[i - 1] = questions[questionIndex, i];
        }

        // Shuffle the answers using Fisher-Yates shuffle algorithm
        for (int i = 0; i < answers.Length; i++)
        {
            int randomIndex = Random.Range(i, answers.Length);
            string temp = answers[randomIndex];
            answers[randomIndex] = answers[i];
            answers[i] = temp;
        }

        // Update the question text and answer buttons
        questionText.text = question;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TMP_Text answerText = answerButtons[i].GetComponentInChildren<TMP_Text>();
            answerText.text = answers[i];
        }
    }

    public void AnswerQuestion(int index)
    {
        for (int i = 1; i <= 4; i++)
        {
            if (answerButtons[index].GetComponentInChildren<TMP_Text>().text == questions[questionIndex, i])
            {
                correctAnswers++;
                break;
            }
        }

        questionIndex++;

        if (questionIndex < questions.GetLength(0))
        {
            ShowQuestion();
        }
        else
        {
            ShowResult();
        }
    }



    void ShowResult()
    {
        quizPanel.SetActive(false); // Disable the quiz panel
        Background.SetActive(false);
        resultPanel.SetActive(true); // Enable the result panel
        resultText.text = "You got " + correctAnswers + " out of 10 questions correct.";

        // Disable all the answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
        // Disable the question text
        questionText.gameObject.SetActive(false);
    }
}