using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public GameObject controlsPanel;
    private bool controlsVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (controlsVisible)
            {
                // Hide controls UI
                controlsPanel.SetActive(false);
                controlsVisible = false;
            }
            else
            {
                // Show controls UI
                controlsPanel.SetActive(true);
                controlsVisible = true;
            }
        }
    }
}
