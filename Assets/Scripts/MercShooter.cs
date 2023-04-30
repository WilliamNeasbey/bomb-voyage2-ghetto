using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercShooter : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = -20f;
    public Transform gunBarrel;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    public float bulletSpeed = 10f;
    public Animator animator;

    private CharacterController controller;
    private Vector3 moveDirection;
    private float nextFireTime = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveHorizontal = transform.right * horizontalInput;
        Vector3 moveVertical = transform.forward * verticalInput;
        moveDirection = (moveHorizontal + moveVertical).normalized;

        // Apply gravity
        moveDirection.y += gravity * Time.deltaTime;

        // Move the player
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Play movement animation
        animator.SetFloat("Speed", moveDirection.magnitude);

        // Check for shooting input
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            // Create a bullet
            GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);

            // Set the bullet's velocity
            bullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * bulletSpeed;

            // Set the next fire time
            nextFireTime = Time.time + fireRate;

            // Play shooting animation
            animator.SetTrigger("Shoot");
        }
    }
}
