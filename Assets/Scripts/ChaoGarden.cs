using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoGarden : MonoBehaviour
{
    public GameObject chaoPrefab; // The prefab for the Chao object
    public int numChao; // The number of Chao to spawn in the garden
    public float spawnRadius; // The maximum distance from the center where the Chao can spawn
    public float maxAge; // The maximum age a Chao can reach before it dies
    public float maxHunger; // The maximum hunger level a Chao can have before it dies
    public float maxSleepiness; // The maximum sleepiness level a Chao can have before it dies

    private List<GameObject> chaoList; // List of all the Chao in the garden

    // Use this for initialization
    void Start()
    {
        chaoList = new List<GameObject>();

        // Spawn the Chao in the garden
        for (int i = 0; i < numChao; i++)
        {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject chao = Instantiate(chaoPrefab, spawnPos, Quaternion.identity);
            chao.transform.parent = transform;
            chaoList.Add(chao);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Loop through all the Chao in the garden
        for (int i = 0; i < chaoList.Count; i++)
        {
            GameObject chao = chaoList[i];
            ChaoController chaoController = chao.GetComponent<ChaoController>();

            // Check if the Chao has died from old age or hunger/sleepiness
            if (chaoController.age >= maxAge || chaoController.hunger >= maxHunger || chaoController.sleepiness >= maxSleepiness)
            {
                // Remove the Chao from the garden
                chaoList.RemoveAt(i);
                Destroy(chao);

                // Spawn a new Chao to replace the dead one
                Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
                GameObject newChao = Instantiate(chaoPrefab, spawnPos, Quaternion.identity);
                newChao.transform.parent = transform;
                chaoList.Add(newChao);
            }
        }
    }
}
