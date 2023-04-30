using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDelay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float delay = 5f;

    void Start()
    {
        Invoke("PlaySound", delay);
    }

    void PlaySound()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
