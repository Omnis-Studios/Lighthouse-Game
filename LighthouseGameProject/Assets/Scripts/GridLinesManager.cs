using UnityEngine;

public class GridLinesManager : MonoBehaviour

{
    public float cellSize = 5.0f; // Size of each cell
    public int gridWidth = 10; // Number of cells horizontally
    public int gridHeight = 10; // Number of cells vertically

    public GameObject gridLinePrefab; // Prefab for the grid line (optional)
    
    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        // Parent object to hold the grid lines
        GameObject gridParent = new GameObject("GridLines");

        // Create vertical lines (along the X-axis)
        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 startPos = new Vector3(x * cellSize, 0, 0);
            Vector3 endPos = new Vector3(x * cellSize, 0, gridHeight * cellSize);
            CreateLine(startPos, endPos, "Vertical", x, -1, gridParent);
        }

        // Create horizontal lines (along the Z-axis)
        for (int z = 0; z <= gridHeight; z++)
        {
            Vector3 startPos = new Vector3(0, 0, z * cellSize);
            Vector3 endPos = new Vector3(gridWidth * cellSize, 0, z * cellSize);
            CreateLine(startPos, endPos, "Horizontal", -1, z, gridParent);
        }
    }

    private void CreateLine(Vector3 start, Vector3 end, string lineType, int xIndex, int zIndex, GameObject parent)
    {
        // Calculate the position and size of the collider
        Vector3 position = (start + end) / 2; // Middle of the line
        Vector3 scale = lineType == "Vertical" ? new Vector3(0.1f, 1, cellSize * gridHeight) : new Vector3(cellSize * gridWidth, 1, 0.1f);
        
        // Create the grid line GameObject
        GameObject line = new GameObject($"{lineType}Line_X{xIndex}_Z{zIndex}");
        line.transform.position = position;
        line.transform.localScale = scale;
        line.transform.parent = parent.transform;

        // Add a Box Collider for triggering
        BoxCollider collider = line.AddComponent<BoxCollider>();
        collider.isTrigger = true;

        // Add the LineID component for metadata
        LineID lineID = line.AddComponent<LineID>();
        lineID.xIndex = xIndex;
        lineID.zIndex = zIndex;
        lineID.lineType = lineType;

        // Optionally, visualize the line
        line.AddComponent<LineRenderer>();
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
    }
}
