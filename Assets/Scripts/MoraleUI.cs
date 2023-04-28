using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoraleUI : MonoBehaviour
{
    public TextMeshProUGUI innocentText;
    public TextMeshProUGUI guiltyText;

    void Start()
    {
        // Get the current values of the Innocent and Guilty player prefs variables
        int innocentValue = PlayerPrefs.GetInt("Innocent", 0);
        int guiltyValue = PlayerPrefs.GetInt("Guilty", 0);

        // Display the values in the text components
        innocentText.text = "Innocent: " + innocentValue.ToString();
        guiltyText.text = "Guilty: " + guiltyValue.ToString();
    }
}
