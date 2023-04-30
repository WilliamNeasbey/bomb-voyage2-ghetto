using System;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public event Action OnPiecePlaced;

    private Texture2D image;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isPlaced = false;

    public bool IsPlaced
    {
        get { return isPlaced; }
    }

    public void SetImage(Texture2D image)
    {
        this.image = image;
        GetComponent<Renderer>().material.mainTexture = image;
    }

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnMouseDown()
    {
        if (!isPlaced)
        {
            transform.Rotate(0f, 0f, 90f);
            isPlaced = true;
            if (OnPiecePlaced != null)
            {
                OnPiecePlaced();
            }
        }
    }
}