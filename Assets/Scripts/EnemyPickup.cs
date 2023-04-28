using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPickup : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float throwForce = 20f;
    public float holdDistance = 2f;
    public LayerMask enemyLayer;

    private Rigidbody playerRigidbody;
    private Collider playerCollider;
    private bool isGrounded = true;
    private bool isCarryingEnemy = false;
    private GameObject carriedEnemy;
    private Vector3 throwDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move player left and right
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        playerRigidbody.velocity = movement * moveSpeed;

        // Jump when spacebar is pressed and player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Pick up enemy when player is colliding with one and press "E"
        if (Input.GetKeyDown(KeyCode.E) && !isCarryingEnemy)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, 1f, enemyLayer);
            if (enemies.Length > 0)
            {
                carriedEnemy = enemies[0].gameObject;
                carriedEnemy.transform.SetParent(transform);
                carriedEnemy.transform.localPosition = new Vector3(0f, 1f, holdDistance);
                carriedEnemy.GetComponent<Rigidbody>().isKinematic = true;
                isCarryingEnemy = true;
            }
        }

        // Release enemy when player is carrying one and press "E" again
        if (Input.GetKeyDown(KeyCode.E) && isCarryingEnemy)
        {
            carriedEnemy.GetComponent<Rigidbody>().isKinematic = false;
            carriedEnemy.transform.SetParent(null);
            carriedEnemy.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce, ForceMode.Impulse);
            isCarryingEnemy = false;
        }

        // Aim at direction to throw the enemy
        if (isCarryingEnemy)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;
            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 targetPoint = ray.GetPoint(rayDistance);
                throwDirection = targetPoint - transform.position;
                throwDirection.y = 0f;
                throwDirection.Normalize();
                carriedEnemy.transform.LookAt(carriedEnemy.transform.position + throwDirection);
            }
        }
    }

    // Check if player is grounded
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
