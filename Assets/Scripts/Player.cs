using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  /*  public float moveSpeed = 5.0f; // The speed at which the player moves
    public float jumpForce = 5.0f; // The force with which the player jumps
    public float throwForce = 10.0f; // The force with which the player throws a Chao
    public float maxPickupDistance = 2.0f; // The maximum distance at which the player can pick up a Chao
    public float pettingDuration = 1.0f; // The duration of the petting animation

    private Animator animator; // The animator component of the player
    private Rigidbody playerRigidbody; // The rigidbody component of the player
    private bool isPetting; // Whether or not the player is currently petting a Chao
    private ChaoController pettingChao; // The Chao that the player is currently petting

    private ChaoController heldChao = null;
    private GameObject heldObject = null;

    //public float throwForce = 5f;
    public float pickupDistance = 2f;

    // Update is called once per frame
    void Update()
    {
        // Check for input to pick up or throw
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (heldChao == null)
            {
                PickUpChao();
            }
            else
            {
                ThrowChao();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                PickUpObject();
            }
            else
            {
                FeedChao();
            }
        }

        // Check for input to pet the chao
        if (Input.GetKeyDown(KeyCode.P))
        {
            PetChao();
        }
    }

    private void PickUpChao()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
        {
            ChaoController chao = hit.collider.GetComponent<ChaoController>();
            if (chao != null)
            {
                heldChao = chao;
                heldChao.PickUp();
            }
        }
    }

    private void ThrowChao()
    {
        heldChao.Throw(transform.forward * throwForce);
        heldChao = null;
    }

    private void PetChao()
    {
        if (heldChao != null)
        {
            heldChao.Pet();
        }
    }

    private void PickUpObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
        {
            GameObject obj = hit.collider.gameObject;
            if (obj.tag == "Food")
            {
                heldObject = obj;
                heldObject.transform.parent = transform;
                heldObject.transform.localPosition = new Vector3(0f, 0.5f, 1f);
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void FeedChao()
    {
        if (heldObject != null && heldChao != null)
        {
            heldChao.Feed(heldObject.GetComponent<Food>().nutritionValue);
            Destroy(heldObject);
            heldObject = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * pickupDistance);
    }*/

}
