using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingPleaseWorkYouPieceOfShit : MonoBehaviour
{
    public Transform ball;
    public Transform[] pins;
    public TMP_Text scoreText;
    public TMP_Text winText;

    private bool ballInPlay;
    private int numPins;
    private int currentFrame;
    private int currentBall;
    private int[] ballScores;
    private int totalScore;
    private bool gameOver;
    private int aiTotalScore;
    private int numFrames = 10;
    public float throwPower = 10.0f;
    float throwStartTime = Time.time;
    public float maxThrowPower = 20.0f;
    private Rigidbody ballRigidbody;

    void Start()
    {
        ballScores = new int[numFrames * 2 + 1];
        currentFrame = 1;
        currentBall = 1;
        gameOver = false;
        aiTotalScore = 0;
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (gameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !ballInPlay)
        {
            ballInPlay = true;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            // Calculate the direction and power of the throw based on how long the Space key is held down
            float throwDirection = Input.GetAxis("Horizontal");
            float throwPower = Mathf.Clamp01(Time.time - throwStartTime) * maxThrowPower;

            // Apply the throw force to the ball Rigidbody
            ballRigidbody.AddForce(new Vector3(throwDirection, 0, 1) * throwPower, ForceMode.Impulse);
        }
    }

    IEnumerator AIThrowsBall()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f)); // Wait for random time between 1 and 3 seconds
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().isKinematic = false;
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-500f, 500f), 0f, Random.Range(1500f, 3000f)));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pin")
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pin")
        {
            float pinHeight = other.transform.position.y;
            if (pinHeight < -1f)
            {
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator CalculateScore()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds to give time for pins to settle
        ballInPlay = false;
        numPins = pins.Length;
        int score = numPins == 0 ? 10 : numPins;
        ballScores[currentFrame * 2 - 2 + currentBall - 1] = score;
        totalScore += score;

        if (currentBall == 2 || numPins == 0)
        {
            currentFrame++;
            currentBall = 1;
        }
        else
        {
            currentBall++;
        }
        if (currentFrame > numFrames)
        {
            gameOver = true;
            if (totalScore > aiTotalScore)
            {
                winText.text = "You win!";
                SceneManager.LoadScene("YouWinScene");
            }
            else if (totalScore < aiTotalScore)
            {
                winText.text = "You lose!";
                SceneManager.LoadScene("YouLoseScene");
            }
            else
            {
                winText.text = "It's a tie!";
                SceneManager.LoadScene("TieScene");
            }
        }
        else
        {
            scoreText.text = "Score: " + totalScore;
        }

        numPins = pins.Length;
        for (int i = 0; i < numPins; i++)
        {
            if (pins[i] == null)
            {
                continue;
            }
            float pinHeight = pins[i].position.y;
            if (pinHeight < 0.1f)
            {
                pins[i] = null;
                numPins--;
            }
        }

        if (!gameOver && currentBall == 1)
        {
            StartCoroutine(AIThrowsBall());
        }
    }
}
