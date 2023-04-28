using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoraleSystem : MonoBehaviour
{
    public Button innocentButton;
    public Button guiltyButton;

    void Start()
    {
        innocentButton.onClick.AddListener(IncrementInnocentValue);
        guiltyButton.onClick.AddListener(IncrementGuiltyValue);
    }

    public void IncrementInnocentValue()
    {
        int innocentValue = PlayerPrefs.GetInt("Innocent", 0);
        innocentValue++;
        PlayerPrefs.SetInt("Innocent", innocentValue);
    }

    public void IncrementGuiltyValue()
    {
        int guiltyValue = PlayerPrefs.GetInt("Guilty", 0);
        guiltyValue++;
        PlayerPrefs.SetInt("Guilty", guiltyValue);
    }

    //PlayerPrefs.GetInt("Guilty", 0)
}
