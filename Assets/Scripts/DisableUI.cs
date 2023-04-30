using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUI : MonoBehaviour
{
     

       public GameObject[] gameObjectsToDisable;

    public void DisableObjectsOnClick()
    {
        foreach (GameObject gameObjectToDisable in gameObjectsToDisable)
        {
            gameObjectToDisable.SetActive(false);
        }
    }
}
