using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image whiteScreen;
    public float fadeTime;

    void Start()
    {
        StartCoroutine(FadeOut1());
    }

    IEnumerator FadeOut1()
    {
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / fadeTime);
            whiteScreen.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }
}

