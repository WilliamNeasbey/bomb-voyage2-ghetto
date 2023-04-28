using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    [SerializeField] private Text textField;
    [SerializeField] private string message;
    [SerializeField] private float scrollSpeed;

    private void Start()
    {
        textField.text = message;
    }

    private void Update()
    {
        // Calculate the new text position based on the scroll speed
        Vector3 newPosition = textField.rectTransform.localPosition;
        newPosition.x -= scrollSpeed * Time.deltaTime;

        // If the text has scrolled past its original position plus its width, reset its position
        if (newPosition.x < -(textField.preferredWidth / 2f))
        {
            newPosition.x = textField.rectTransform.rect.width / 2f;
        }

        // Set the text's new position
        textField.rectTransform.localPosition = newPosition;
    }
}
