using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public string LevelToLoad;
    public GameObject[] objectsToDisable;
    public GameObject[] objectsToEnable;
    public GameObject objectToDisable;
    public GameObject plotObject;

    public void DisableObjectsOnClick()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }

    public void EnableObjectsOnClick()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void LoadLaunchTheBozo()
    {
        SceneManager.LoadScene("LaunchTheBozo");
    }

    public void LoadLobbyHub()
    {
        SceneManager.LoadScene("LobbyHub");
    }

    public void LoadTwitchFollowers()
    {
        SceneManager.LoadScene("TwitchFollowers");
    }

    public void DisableObject()
    {
        objectToDisable.SetActive(false);
    }

    public void ShowPlot()
    {
        plotObject.SetActive(true);
    }
}

