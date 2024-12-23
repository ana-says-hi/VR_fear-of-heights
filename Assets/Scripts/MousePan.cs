using UnityEngine;

public class MousePan : MonoBehaviour
{
    public float sensitivity = 100f; // Mouse sensitivity
    float xRotation = 0f; // Tracks vertical (up/down) rotation
    float yRotation = 0f; // Tracks horizontal (left/right) rotation
    public GameObject cameraHelper;

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Update vertical rotation (clamp to avoid flipping the camera upside down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Update horizontal rotation (no clamping for full 360� rotation)
        yRotation += mouseX;

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        cameraHelper.transform.localRotation=Quaternion.Euler(0f, yRotation, 0f);
        
    }
}
