using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public float glowIntensity = 1f;
    public float glowThreshold = 1f;

    private Material material;

    void Start()
    {
        // Create a new material using the "Particles/Standard Unlit" shader
        material = new Material(Shader.Find("Particles/Standard Unlit"));

        // Set the material color to white
        material.SetColor("_Color", Color.white);

        // Set the material's blend mode to additive
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);

        // Disable backface culling
        material.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
    }

    void OnRenderObject()
    {
        // Enable the glow effect
        material.EnableKeyword("_EMISSION");

        // Set the material's emission color to white and intensity to the desired value
        material.SetColor("_EmissionColor", Color.white * glowIntensity);

        // Set the material's threshold value to control the size of the glow effect
        material.SetFloat("_Threshold", glowThreshold);

        // Draw the game object's mesh using the material
        Graphics.DrawMesh(GetComponent<MeshFilter>().mesh, transform.position, transform.rotation, material, 0);
    }
}
