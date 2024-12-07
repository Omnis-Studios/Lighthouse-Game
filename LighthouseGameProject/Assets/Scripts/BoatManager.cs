using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public GameObject boatPrefab;
    public GridManager gridManager; // Reference to the GridManager
    public float spawnInterval = 2.0f;

    private List<(GameObject GameObject, string Code)> boatList = new List<(GameObject GameObject, string Code)>();

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

        string boatCode = codeGenerator();
        for (int i = 0; i < boatList.Count; i++)
        {
            while ((boatList[i].Code) == boatCode )
            {
                Debug.Log("Code has been repeated");
                boatCode = codeGenerator();
                i = 0;
            }
        }
        
        Boat boatComponent = boat.GetComponent<Boat>();
        if (boatComponent != null)
        {
            boatComponent.SetBoatCode(boatCode);
        }

        boatList.Add((boat, boatCode));
    }
    
    private string codeGenerator()
    {
        string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        char c = st[Random.Range(0, st.Length)];
        int num = Random.Range(10, 99);

        string code = c + num.ToString();
        return code;

    }
}