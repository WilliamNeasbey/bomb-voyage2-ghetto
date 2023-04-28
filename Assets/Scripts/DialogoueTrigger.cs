using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogoueTrigger : MonoBehaviour
{
    public GameObject uiCanvas; // Assign the UI canvas to this in the Inspector
    private bool canSpawnUI = false;
    public GameObject EToEnable;

    private void OnTriggerEnter(Collider other)
    {
        EToEnable.SetActive(true);
        if (other.CompareTag("Player"))
        {
            
            canSpawnUI = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpawnUI = false;
            uiCanvas.SetActive(false); // Deactivate the UI canvas when the player leaves the collision box
            EToEnable.SetActive(false);
        }
    }

    private void Update()
    {
        if (canSpawnUI && Input.GetKeyDown(KeyCode.E))
        {
            uiCanvas.SetActive(true); // Activate the UI canvas when the player presses E
            EToEnable.SetActive(false);
        }
    }

    public void Disable()
    {
        EToEnable.SetActive(false);
    }
}
