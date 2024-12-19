using UnityEngine;

public class MousePan : MonoBehaviour
{
    public float sensitivity = 100f; // Mouse sensitivity
    float xRotation = 0f; // Tracks vertical rotation

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

        // Vertical rotation (clamped to avoid flipping the camera)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation: vertical to the camera (local), horizontal to the camera (global)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX, Space.World);
    }
}
