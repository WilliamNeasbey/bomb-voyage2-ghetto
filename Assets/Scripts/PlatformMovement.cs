using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 7f;
    public float pickupRadius = 2f;
    public LayerMask pickupLayer;
    public Transform itemHolder;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private GameObject pickedUpItem;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(move * speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(transform.position, 0.2f, LayerMask.GetMask("Ground"));

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E) && pickedUpItem == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRadius, pickupLayer);

            if (hitColliders.Length > 0)
            {
                pickedUpItem = hitColliders[0].gameObject;
                pickedUpItem.transform.SetParent(itemHolder);
                pickedUpItem.transform.localPosition = Vector3.zero;
                pickedUpItem.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && pickedUpItem != null)
        {
            pickedUpItem.transform.SetParent(null);
            pickedUpItem.GetComponent<Rigidbody>().isKinematic = false;
            pickedUpItem.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
            pickedUpItem = null;
        }
    }
}
