using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public GameObject boatPrefab;
    public GridManager gridManager; // Reference to the GridManager
    public float spawnInterval = 2.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBoat), 0, spawnInterval);
    }

    private void SpawnBoat()
    {
        // Get all outer grid positions and directions
        var outerPositions = gridManager.GetOuterGridPositions();

        // Randomly select one
        var (spawnPosition, direction) = outerPositions[Random.Range(0, outerPositions.Count)];

        // Spawn the boat and set its rotation
        GameObject boat = Instantiate(boatPrefab, spawnPosition, Quaternion.LookRotation(direction));
    }
}