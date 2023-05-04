using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YlevelTelleport : MonoBehaviour
{
    [SerializeField] private float yThreshold = -10f; // the y-level at which the teleport should trigger
    [SerializeField] private Transform teleportLocation; // the empty game object to teleport to

    private void Update()
    {
        if (transform.position.y < yThreshold)
        {
            transform.position = teleportLocation.position;
        }
    }
}
