using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 100f;
    public bool isPickedUp = false;
    public float age; // The current age of the Chao
    public float hunger; // The current hunger level of the Chao
    public float sleepiness; // The current sleepiness level of the Chao
    public float maxHunger; // The maximum hunger level of the Chao
    public float maxSleepiness; // The maximum sleepiness level of the Chao
    public float hungerIncreaseRate; // The rate at which hunger increases
    public float sleepinessIncreaseRate; // The rate at which sleepiness increases
    public float ageIncreaseRate; // The rate at which age increases

    private float hungerDecreaseRate = 0.5f; // The rate at which hunger decreases
    private float sleepinessDecreaseRate = 0.25f; // The rate at which sleepiness decreases

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Increase the Chao's age, hunger, and sleepiness levels
        age += ageIncreaseRate * Time.deltaTime;
        hunger += hungerIncreaseRate * Time.deltaTime;
        sleepiness += sleepinessIncreaseRate * Time.deltaTime;

        // Decrease the Chao's hunger and sleepiness levels
        hunger = Mathf.Clamp(hunger - hungerDecreaseRate * Time.deltaTime, 0, maxHunger);
        sleepiness = Mathf.Clamp(sleepiness - sleepinessDecreaseRate * Time.deltaTime, 0, maxSleepiness);

        if (!isPickedUp)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
        }

    }

    public void PickUp()
    {
        isPickedUp = true;
        animator.SetBool("isPickedUp", true);
    }

    public void Drop()
    {
        isPickedUp = false;
        animator.SetBool("isPickedUp", false);
    }

    public void Pet()
    {
        animator.SetTrigger("isPetting");
    }

    public void StopMovement()
    {
        moveSpeed = 0;
        rotateSpeed = 0;
    }

    public void ResumeMovement()
    {
        moveSpeed = 3f;
        rotateSpeed = 100f;
    }

    public void Throw(float throwForce)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        isPickedUp = false;
        animator.SetBool("isPickedUp", false);
    }
}
