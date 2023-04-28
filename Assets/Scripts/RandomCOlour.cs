using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCOlour : MonoBehaviour
{
    public Material material; // assign the material in the Inspector

    private void Start()
    {
        // generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // apply the color to the material
        material.color = randomColor;
    }
}
