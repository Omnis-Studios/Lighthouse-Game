using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoatMovement : MonoBehaviour
{

    public float speed = 2.0f;
    public float turnSpeed = 50.0f;
    
    public TextMeshPro textAboveBoat;

    private string boatCode;
    
    private bool isTurning = false;
    private Quaternion targetRotation;
    private GridManager gridManager;
    

    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        boatCode = codeGenerator();
        if (textAboveBoat != null)
        {
            textAboveBoat.text = boatCode;
        }
    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        

        if (!isTurning && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartTurn(-90); // Turn left
        }
        
        else if (!isTurning && Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartTurn(90); // Turn right
        }
        
        if (isTurning)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f) // Check if the rotation is complete
            {
                isTurning = false;
            }
        }
        
        CheckBounds();
    }

    private void StartTurn(float angle)
    {
        isTurning = true;
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, angle, 0));
    }
    
    private void CheckBounds()
    {
        Bounds gridBounds = gridManager.GetGridBounds();
        if (!gridBounds.Contains(transform.position))
        {
            Destroy(gameObject); // Despawn the boat if it's outside the grid
        }
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
