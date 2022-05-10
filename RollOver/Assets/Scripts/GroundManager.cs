using UnityEngine;
using System.Collections.Generic;

public class GroundManager : MonoBehaviour
{
    public GameObject[] pieceOfGroundPrefabs; // The list of the PiecesOfGround prefabs

    public float zSpawn = 0;

    public float pieceLength = 30; // The length of the PiecesOfGround

    public int numberOfPieces = 8; // The number of PiecesOfGround on the scene at the same time

    private List<GameObject> activePieces = new List<GameObject>(); // To store the list of the active pieces

    public Transform playerTransform;

    private int randomPiece; // To store a random index in activePieces[] list
    private int previousPiece = 5259; // To store the index of the previous PiecesOfGround 

    void Start()
    {
        for (int i = 0; i < numberOfPieces; i++)
        {
            if (i == 0)
            {
                // Spawn the piece at index 0, there is only the ground without other objects
                SpawnPiece(0);
                SpawnPiece(0);
            }
            else
            {
                randomPiece = Random.Range(1, pieceOfGroundPrefabs.Length); // Generate a random index number

                if (randomPiece != previousPiece) // In order not to spawn the same piece in a row
                {
                    SpawnPiece(randomPiece);
                    previousPiece = randomPiece;
                }
            }
        }
    }

    void Update()
    {
        if ( playerTransform.position.z - 60 > zSpawn - (numberOfPieces * pieceLength))
        {
            randomPiece = Random.Range(1, pieceOfGroundPrefabs.Length); // Generate a random index number

            if (randomPiece != previousPiece) // In order not to spawn the same piece in a row
            {
                SpawnPiece(randomPiece);
                DeletePiece();
                previousPiece = randomPiece;
            }
        }
    }

    public void SpawnPiece(int pieceIndex)
    {
        GameObject gameObject = Instantiate(pieceOfGroundPrefabs[pieceIndex], transform.forward * zSpawn, transform.rotation);
        activePieces.Add(gameObject);
        zSpawn += pieceLength;
    }

    private void DeletePiece()
    {
        Destroy(activePieces[0]);
        activePieces.RemoveAt(0);
    }
}
