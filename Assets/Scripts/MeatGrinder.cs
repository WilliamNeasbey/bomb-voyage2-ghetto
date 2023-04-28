using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatGrinder : MonoBehaviour
{
    public float particleDuration = 5.0f;
    public GameObject soundObject;
    public GameObject particle1;
    public GameObject particle2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = soundObject.GetComponent<AudioSource>();
        particle1.SetActive(false);
        particle2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cutie"))
        {
            // Play sound effect
            audioSource.Play();

            // Activate particle systems
            particle1.SetActive(true);
            particle2.SetActive(true);

            // Destroy cutie game object
            Destroy(other.gameObject);

            //Add vbucks
            PlayerPrefs.SetInt("vbucks", PlayerPrefs.GetInt("vbucks") + 10);

            // Deactivate particle systems after duration
            Invoke("DeactivateParticles", particleDuration);
          
        }
    }

    void DeactivateParticles()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
    }
}
