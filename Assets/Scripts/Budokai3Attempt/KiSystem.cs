using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KiSystem : MonoBehaviour
{
    public Slider[] kiBars; // an array of ki bars (sliders)
    public float maxKi; // maximum ki value
    public float kiFillSpeed; // ki fill speed
    public float kiDepleteSpeed; // ki deplete speed
    public float kiChargeRate; // ki charge rate per second
    public float kiChargeDelay; // delay before ki starts charging
    public ParticleSystem kiParticle; // particle effect for ki charging
    public AudioSource kiChargingSound; // audio source for ki charging sound

    private float[] kiLevels; // current ki levels for each bar
    private bool isCharging; // flag to check if ki is currently charging
    private float currentKi; // current ki level

    private Color fullColor = Color.yellow; // color of the filled part of the ki bar
    private Color emptyColor = Color.gray; // color of the empty part of the ki bar

    void Start()
    {
        kiLevels = new float[kiBars.Length];
        for (int i = 0; i < kiLevels.Length; i++)
        {
            kiLevels[i] = 0f;
            kiBars[i].maxValue = maxKi;
            kiBars[i].value = kiLevels[i];
        }
        isCharging = false;
        currentKi = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isCharging && currentKi == maxKi)
            {
                kiChargingSound.Play();
                kiParticle.Play();
                isCharging = true;
                StartCoroutine(ChargeKi());
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            kiChargingSound.Stop();
            kiParticle.Stop();
            isCharging = false;
            StopCoroutine(ChargeKi());
        }

        // update the ki bars based on current ki levels
        for (int i = 0; i < kiBars.Length; i++)
        {
            kiBars[i].value = kiLevels[i];
            kiBars[i].fillRect.GetComponent<Image>().color = Color.Lerp(emptyColor, fullColor, kiLevels[i] / maxKi);
        }
    }

    IEnumerator ChargeKi()
    {
        yield return new WaitForSeconds(kiChargeDelay);

        while (currentKi < maxKi && isCharging)
        {
            currentKi += kiChargeRate * Time.deltaTime;
            for (int i = 0; i < kiLevels.Length; i++)
            {
                kiLevels[i] = currentKi;
            }
            yield return null;
        }

        if (currentKi >= maxKi)
        {
            currentKi = maxKi;
            for (int i = 0; i < kiLevels.Length; i++)
            {
                kiLevels[i] = currentKi;
            }
        }
    }
}



