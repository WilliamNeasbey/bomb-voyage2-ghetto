using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnClick : MonoBehaviour
{
    public GameObject uiPanel;

    private void OnMouseDown()
    {
        uiPanel.SetActive(true);
        DisableObjectsOnClick();
    }

    //this is to try and remove other UI
    public GameObject[] gameObjectsToDisable;

    public void DisableObjectsOnClick()
    {
        foreach (GameObject gameObjectToDisable in gameObjectsToDisable)
        {
            gameObjectToDisable.SetActive(false);
        }
    }

}
