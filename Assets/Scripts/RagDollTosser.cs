using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollTosser : MonoBehaviour
{
    private Vector3 offset;
    private Rigidbody rb;

    private void OnMouseDown()
    {
        rb = GetComponent<Rigidbody>();
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) + offset;
        rb.MovePosition(newPosition);
    }
}
