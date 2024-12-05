using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public GameObject boatPrefab;
    public float spawnInterval = 2.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBoat), 0, spawnInterval);
    }

    private void SpawnBoat()
    {
        Instantiate(boatPrefab, transform.position, transform.rotation);
    }
}
