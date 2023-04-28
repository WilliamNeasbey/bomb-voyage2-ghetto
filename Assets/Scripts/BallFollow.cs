using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollow : MonoBehaviour
{

    public GameObject ball;
    public float staticYPosition;

    void Update()
    {
       if(ball.transform.position.y <-0f)
        {
            transform.position = new Vector3(ball.transform.position.x, staticYPosition, -10f);
        }
        else
        {
            transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, -10f);
        }
    }
}
