using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JigsawPuzzle : MonoBehaviour
{
    public int rows = 3;
    public int columns = 3;
    public float pieceSize = 1f;
    public GameObject puzzlePiecePrefab;
    public Texture2D image;
    public string nextSceneName;

    private List<GameObject> puzzlePieces = new List<GameObject>();
    private bool isCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Split the image into pieces
        Texture2D[] pieces = ImageSlicer.SplitImage(image, rows, columns);

        // Create puzzle pieces
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject puzzlePiece = Instantiate(puzzlePiecePrefab);
                puzzlePiece.transform.position = new Vector3(j * pieceSize, i * pieceSize, 0f);
                puzzlePiece.GetComponent<PuzzlePiece>().SetImage(pieces[i * columns + j]);
                puzzlePiece.GetComponent<PuzzlePiece>().OnPiecePlaced += CheckCompleted;
                puzzlePieces.Add(puzzlePiece);
            }
        }
    }

    void CheckCompleted()
    {
        foreach (GameObject piece in puzzlePieces)
        {
            if (!piece.GetComponent<PuzzlePiece>().IsPlaced)
            {
                isCompleted = false;
                return;
            }
        }

        isCompleted = true;

        if (isCompleted)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}