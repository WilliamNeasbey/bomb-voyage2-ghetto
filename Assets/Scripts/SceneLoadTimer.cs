using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTimer : MonoBehaviour
{
    private float timer = 0f;
    private float loadTime = 18f;
    private bool hasLoaded = false;
    public string sceneName;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > loadTime && !hasLoaded)
        {
            hasLoaded = true;
            SceneManager.LoadScene(sceneName);
        }
    }
}
