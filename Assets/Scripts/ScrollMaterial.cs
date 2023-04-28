using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMaterial : MonoBehaviour
{
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;

    private Renderer renderer;
    private Material material;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    private void Update()
    {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
