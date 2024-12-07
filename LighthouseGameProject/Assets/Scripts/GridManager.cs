using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public float cellSize = 5.0f; // Size of each grid cell
    public int gridWidth = 10;    // Number of cells horizontally
    public int gridHeight = 10;   // Number of cells vertically
    public Color gridColor = Color.green; // Color of the grid lines

    // Get all the outer grid positions and their inward directions
    public List<(Vector3 position, Vector3 direction)> GetOuterGridPositions()
    {
        List<(Vector3, Vector3)> outerPositions = new List<(Vector3, Vector3)>();

        // Top and bottom edges
        for (int x = 0; x < gridWidth; x++)
        {
            outerPositions.Add((GetCellCenter(new Vector3(x * cellSize, 0, 0)), Vector3.forward)); // Bottom edge facing up
            outerPositions.Add((GetCellCenter(new Vector3(x * cellSize, 0, (gridHeight - 1) * cellSize)), Vector3.back)); // Top edge facing down
        }

        // Left and right edges
        for (int z = 0; z < gridHeight; z++)
        {
            outerPositions.Add((GetCellCenter(new Vector3(0, 0, z * cellSize)), Vector3.right)); // Left edge facing right
            outerPositions.Add((GetCellCenter(new Vector3((gridWidth - 1) * cellSize, 0, z * cellSize)), Vector3.left)); // Right edge facing left
        }

        return outerPositions;
    }
    
    public Bounds GetGridBounds()
    {
        float gridWidthWorld = gridWidth * cellSize;
        float gridHeightWorld = gridHeight * cellSize;

        Vector3 center = new Vector3(gridWidthWorld / 2, 0, gridHeightWorld / 2);
        Vector3 size = new Vector3(gridWidthWorld, 0, gridHeightWorld);

        return new Bounds(center, size);
    }

    // Snap a position to the center of the nearest grid cell
    public Vector3 GetCellCenter(Vector3 position)
    {
        float x = Mathf.Round(position.x / cellSize) * cellSize + (cellSize / 2);
        float z = Mathf.Round(position.z / cellSize) * cellSize + (cellSize / 2);
        return new Vector3(x, position.y, z);
    }

    // Draw the grid in the Scene view for debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = gridColor;

        // Draw horizontal lines
        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, 0, gridHeight * cellSize);
            Gizmos.DrawLine(start, end);
        }

        // Draw vertical lines
        for (int z = 0; z <= gridHeight; z++)
        {
            Vector3 start = new Vector3(0, 0, z * cellSize);
            Vector3 end = new Vector3(gridWidth * cellSize, 0, z * cellSize);
            Gizmos.DrawLine(start, end);
        }

        // Draw the center of each cell for clarity
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 cellCenter = GetCellCenter(new Vector3(x * cellSize, 0, z * cellSize));
                Gizmos.DrawSphere(cellCenter, 0.2f); // Small sphere to visualize cell centers
            }
        }
    }
}
