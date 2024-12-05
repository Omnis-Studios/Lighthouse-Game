using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject camera;
    public float cameraSpeed = 5.0f;
    public float lookDownSpeed = 5.0f;
    
    private bool isLookingDown = false;
    private bool isMovingDown = false;
    private Quaternion targetRotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !isLookingDown && !isMovingDown)
        {
            transform.Rotate(Vector3.up, -cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && !isLookingDown && !isMovingDown)
        {
            transform.Rotate(Vector3.up, cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isLookingDown && !isMovingDown)
        {
            Debug.Log("Looking down");
            isLookingDown = true;
            StartLook(58);
        }
        else if (Input.GetKeyDown(KeyCode.W) && isLookingDown && !isMovingDown)
        {
            Debug.Log("Looking up");
            isLookingDown = false;
            StartLook(-58);
        }
        
        if (isMovingDown)
        {
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, targetRotation, lookDownSpeed * Time.deltaTime);
            if (Quaternion.Angle(camera.transform.rotation, targetRotation) < 0.1f) // Check if the rotation is complete
            {
                isMovingDown = false;
            }
        }
        
        
        
    }
    
    private void StartLook(float angle)
    {
        isMovingDown = true;
        targetRotation = Quaternion.Euler(camera.transform.eulerAngles + new Vector3(angle, 0, 0));
    }
}
