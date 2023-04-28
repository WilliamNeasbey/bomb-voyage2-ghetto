using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    public float despawnTime = 5f; // The time (in seconds) until the object despawns

    private void Start()
    {
        Invoke("Despawn", despawnTime);
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
