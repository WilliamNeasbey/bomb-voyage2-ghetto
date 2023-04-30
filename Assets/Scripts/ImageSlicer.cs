using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSlicer : MonoBehaviour
{
    public static Texture2D[] SplitImage(Texture2D image, int rows, int columns)
    {
        int pieceWidth = image.width / columns;
        int pieceHeight = image.height / rows;

        Texture2D[] pieces = new Texture2D[rows * columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Texture2D piece = new Texture2D(pieceWidth, pieceHeight);
                Color[] pixels = image.GetPixels(j * pieceWidth, i * pieceHeight, pieceWidth, pieceHeight);
                piece.SetPixels(pixels);
                piece.Apply();
                pieces[i * columns + j] = piece;
            }
        }

        return pieces;
    }
}