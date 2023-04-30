using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterDelay : MonoBehaviour
{
    public DisableObject objectToDisable;
    public float delay = 5f;

    void Start()
    {
        StartCoroutine(DisableObjectAfterDelay());
    }

    IEnumerator DisableObjectAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        objectToDisable.Disable();
    }
}
