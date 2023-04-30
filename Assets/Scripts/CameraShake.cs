using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera mainCamera;
    public float shakeIntensity = 0.1f;
    public float shakeFrequency = 10f;

    void ShakeCamera()
    {
        float x = Random.Range(-1f, 1f) * shakeIntensity;
        float y = Random.Range(-1f, 1f) * shakeIntensity;
        mainCamera.transform.position += new Vector3(x, y, 0);
    }

    float timeElapsed = 0f;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1f / shakeFrequency)
        {
            ShakeCamera();
            timeElapsed = 0f;
        }
    }
}
