using UnityEngine;

public class Boat : MonoBehaviour
{
    private string boatCode;

    public void SetBoatCode(string code)
    {
        boatCode = code;
    }

    public string GetBoatCode()
    {
        return boatCode;
    }
}