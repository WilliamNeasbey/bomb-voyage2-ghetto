using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomSeed : MonoBehaviour
{
    public string StringSeed = "seed string";
    public bool UseStringSeed;
    public int seed;
    public bool RandomizeSeed;

    private void Awake()
    {
        if (UseStringSeed)
        {
            seed = StringSeed.GetHashCode();
        }

        if (RandomizeSeed)
        {
            seed = Random.Range(0, 99999999);
        }

        Random.InitState(seed);
    }

}
