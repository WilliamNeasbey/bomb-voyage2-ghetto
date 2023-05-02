using UnityEngine;

public class EnableDisableObject : MonoBehaviour
{
    public GameObject objectToToggle; // The game object to enable/disable
    public float timerLength = 5.0f; // The length of the timer in seconds

    private float timer = 0.0f; // The current time elapsed
    private bool hasToggled = false; // Whether the object has been toggled already

    void Update()
    {
        // If the object has already been toggled, exit the function
        if (hasToggled)
        {
            return;
        }

        // Increment the timer each frame
        timer += Time.deltaTime;

        // Check if the timer has reached the desired length
        if (timer >= timerLength)
        {
            // Toggle the object's active state
            objectToToggle.SetActive(!objectToToggle.activeSelf);

            // Mark the object as toggled
            hasToggled = true;
        }
    }
}