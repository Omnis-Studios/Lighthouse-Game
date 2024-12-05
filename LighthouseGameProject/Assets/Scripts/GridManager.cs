using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float cellSize = 5.0f; // Size of each grid cell

    // Snap a position to the center of the nearest grid cell
    public Vector3 GetCellCenter(Vector3 position)
    {
        float x = Mathf.Round(position.x / cellSize) * cellSize;
        float z = Mathf.Round(position.z / cellSize) * cellSize;
        return new Vector3(x, position.y, z);
    }
}
