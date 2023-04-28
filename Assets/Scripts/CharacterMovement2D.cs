using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;    // Player movement speed
    public float jumpForce = 7f;    // Player jump force
    public Transform groundCheck;   // Ground check transform
    public LayerMask groundLayer;   // Layer mask for ground objects

    private Rigidbody playerRigidbody;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        // Player movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        playerRigidbody.velocity = new Vector3(movement.x * moveSpeed, playerRigidbody.velocity.y, movement.z * moveSpeed);

        // Player jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
