using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float explosionRadius = 5f;
    public float explosionForce = 500f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Spawn a projectile at the position of this game object
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Get the direction towards the mouse position
            Vector3 direction = GetMouseDirection();

            // Set the velocity of the projectile to move towards the mouse direction
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = direction * projectileSpeed;

            // Set the explosive properties of the projectile
            ProjectileExplosive explosive = projectile.GetComponent<ProjectileExplosive>();
            explosive.explosionRadius = explosionRadius;
            explosive.explosionForce = explosionForce;
        }
    }

    Vector3 GetMouseDirection()
    {
        // Get the mouse position on the screen
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to a world position
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Get the direction towards the mouse position
        Vector3 direction = worldMousePosition - transform.position;
        direction.z = 0f;
        direction.Normalize();

        return direction;
    }
}

public class ProjectileExplosive : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 500f;

    void OnCollisionEnter(Collision collision)
    {
        // Explode on impact
        Explode();
    }

    void Explode()
    {
        // Find all objects in the explosion radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            // Apply explosive force to objects in the explosion radius
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // Destroy this game object
        Destroy(gameObject);
    }
}
