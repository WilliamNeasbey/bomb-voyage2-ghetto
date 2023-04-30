using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegaTimer : MonoBehaviour
{
    IEnumerator ActivateGameObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(true);
    }

    public float delay = 5f;

    void Awake()
    {
        StartCoroutine(ActivateGameObject(delay));
    }
}
