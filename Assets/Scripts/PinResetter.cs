using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinResetter : MonoBehaviour
{
  /*  public GameObject pinsPrefab;           // Prefab for the pins
    public Transform pinsSpawnPoint;        // Transform of where the pins should be spawned
    public BowlingGame bowlingGame;         // Reference to the BowlingGame script

    [HideInInspector]
    public GameObject pins;                 // Reference to the current set of pins

    private bool isPinsResetting = false;   // Are the pins currently resetting?

    public void ResetPins()
    {
        if (!isPinsResetting)
        {
            // Spawn a new set of pins and set their parent to this object
            pins = Instantiate(pinsPrefab, pinsSpawnPoint.position, Quaternion.identity);
            pins.transform.parent = transform;

            // Set the bowling game's isPlayerTurn variable to true and reset the score
            bowlingGame.isPlayerTurn = true;
            bowlingGame.score = 0;
            bowlingGame.scoreText.text = "Score: " + bowlingGame.score;
        }
    }

    public void PinsHaveSettled()
    {
        // Wait for a short delay to ensure the pins have settled
        StartCoroutine(DoResetPins());
    }

    IEnumerator DoResetPins()
    {
        isPinsResetting = true;

        yield return new WaitForSeconds(1f);

        // Move the pins back to their starting position and reset their rotation and velocity
        pins.transform.position = pinsSpawnPoint.position;
        pins.transform.rotation = Quaternion.identity;
        pins.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pins.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // Destroy the old set of pins and spawn a new set
        Destroy(pins);
        pins = Instantiate(pinsPrefab, pinsSpawnPoint.position, Quaternion.identity);
        pins.transform.parent = transform;

        isPinsResetting = false;
    }*/
}
