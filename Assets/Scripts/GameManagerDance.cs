using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerDance : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManagerDance instance;

    public int currentScore;

    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplayer;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplayer = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;

        startPlaying = true;
        theBS.hasStarted = true;

        theMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if(percentHit > 40)
                {
                    rankVal = "D";
                    if (percentHit > 55)
                    {
                        rankVal = "C";
                            if (percentHit > 70)
                        {
                            rankVal = "B";
                                 if (percentHit > 85)
                            {
                                rankVal = "A";
                                    if (percentHit > 95)
                                {
                                    rankVal = "S";
                                        if (percentHit > 100)
                                    {
                                        rankVal = "Super Sexy Legend";
                                    }
                                }
                            }
                        }

                    }

                }
                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();


            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMultiplayer - 1 < multiplierThresholds.Length)
        {

            multiplierTracker++;

            if (multiplierThresholds[currentMultiplayer - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplayer++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplayer;

        //currentScore += scorePerNote * currentMultiplayer;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote + currentMultiplayer;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote + currentMultiplayer;

        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote + currentMultiplayer;

        NoteHit();
        perfectHits++;

    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplayer = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplayer;

        missedHits++;
    }
}
