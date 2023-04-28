using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaunchBall : MonoBehaviour
{
    public int NumberOfClicks = 0;
    public int power = 50;
    public Transform LaunchDirection;
    public Rigidbody rb;
    private bool allowedToClick = false;
    private bool didOnce = false;

    public TextMeshProUGUI ready;
    public TextMeshProUGUI go;

    private float score = 0;
    public TextMeshProUGUI ScoreText;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!didOnce)
        {
            didOnce = true;
            ready.enabled = true;
            //audioSource.Play();
            Invoke("Go", 2f);
            Invoke("Launch", 9f);

        }
        if(allowedToClick && Input.GetKeyDown(KeyCode.Mouse0))
        {
            NumberOfClicks++;
        }
        score = (int)(transform.position.x * 100);
        ScoreText.SetText("Score:  " + score);
        
    }

    void Launch()
    {
        rb.AddForce(LaunchDirection.up * (power * NumberOfClicks));
        allowedToClick = false;
    }

    void Go()
    {
        ready.enabled = false;
        allowedToClick = true;
        go.enabled = true;
        audioSource.Play();
        Invoke("StopGo", 1f);
    }

    void StopGo()
    {
        go.enabled = false;
    }
}
