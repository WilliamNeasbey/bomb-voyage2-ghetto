using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightClickButton : MonoBehaviour
{
    public Button button;
    public KeyCode activateKey = KeyCode.Space;
    public EventSystem eventSystem;

    void Update()
    {
        if (Input.GetKeyDown(activateKey))
        {
            ActivateButton();
        }
    }

    public void ActivateButton()
    {
        if (button != null)
        {
            // Create a new PointerEventData
            PointerEventData pointerEventData = new PointerEventData(eventSystem);

            // Set the pointer position to the center of the screen
            pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2);

            // Use ExecuteEvents to simulate a click on the button
            ExecuteEvents.Execute(button.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
        }
    }
}