using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class TextData
{
    public string text;
    public AudioClip sound;
    public GameObject imageObject;
}

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public Button nextButton;
    public TextData[] texts;
    public Canvas nextCanvas;
    public GameObject canvasToDisable;
    public bool disableCanvasOnComplete = false;

    private int currentTextIndex = 0;
    private AudioSource audioSource;
    private GameObject currentImageObject;
    private bool isPlayingSound = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShowCurrentText();
    }

    private void ShowCurrentText()
    {
        textDisplay.text = texts[currentTextIndex].text;
        PlaySound(texts[currentTextIndex].sound);
        ShowImageObject();
    }

    private void PlaySound(AudioClip sound)
    {
        if (sound != null)
        {
            audioSource.clip = sound;
            audioSource.Play();
            isPlayingSound = true;
        }
        else
        {
            isPlayingSound = false;
        }
    }

    private void ShowImageObject()
    {
        if (currentImageObject != null)
        {
            currentImageObject.SetActive(false);
        }
        currentImageObject = texts[currentTextIndex].imageObject;
        if (currentImageObject != null)
        {
            currentImageObject.SetActive(true);
        }
    }

    public void OnNextButtonClicked()
    {
        currentTextIndex++;
        if (isPlayingSound)
        {
            audioSource.Stop();
        }
        if (currentTextIndex >= texts.Length)
        {
            EnableNextCanvas();
            if (disableCanvasOnComplete)
            {
                canvasToDisable.SetActive(false);
            }
        }
        else
        {
            ShowCurrentText();
        }
    }

    private void EnableNextCanvas()
    {
        nextCanvas.enabled = true;
    }
}