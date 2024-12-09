using UnityEngine;

public class LineID : MonoBehaviour
{
    public int xIndex; // Index of the line along the X-axis (for vertical lines)
    public int zIndex; // Index of the line along the Z-axis (for horizontal lines)
    public string lineType; // Either "Vertical" or "Horizontal"

    private void Awake()
    {
        // Automatically name the line for debugging
        gameObject.name = $"GridLine_{lineType}_X{xIndex}_Z{zIndex}";
    }
}