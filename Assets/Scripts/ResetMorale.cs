using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetMorale : MonoBehaviour
{
    public Button resetButton;

    void Start()
    {
        resetButton.onClick.AddListener(ResetValues);
    }

    public void ResetValues()
    {
        PlayerPrefs.SetInt("Innocent", 0);
        PlayerPrefs.SetInt("Guilty", 0);
    }
}
