using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterDelay : MonoBehaviour
{
    public EnableObject objectToEnable;
    public float delay = 5f;

    void Start()
    {
        StartCoroutine(EnableObjectAfterDelay());
    }

    IEnumerator EnableObjectAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        objectToEnable.Enable();
    }

    }
