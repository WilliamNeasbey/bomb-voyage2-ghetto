using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class VBucksTracker : MonoBehaviour
{
    public TextMeshProUGUI vbucksText;

    void Update()
    {
        // Retrieve the value of the PlayerPrefs integer "vbucks"
        int vbucks = PlayerPrefs.GetInt("vbucks", 0);

        // Update the TextMeshProUGUI component to display the vbucks value
        vbucksText.text = vbucks.ToString();
    }
}
