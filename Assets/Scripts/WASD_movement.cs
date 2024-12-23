using UnityEngine;

public class WASD_movement : MonoBehaviour
{
    public float moveSpeed = 10f;       // Movement speed
    public Transform cameraTransform;  // Reference to the camera's transform
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
        }

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Automatically assign the Main Camera
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Get input from WASD keys
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ += 1f;
        if (Input.GetKey(KeyCode.S)) moveZ -= 1f;
        if (Input.GetKey(KeyCode.A)) moveX -= 1f;
        if (Input.GetKey(KeyCode.D)) moveX += 1f;

        // Combine inputs into a direction vector
        Vector3 inputDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Get the camera's forward and right directions, ignoring the Y component
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f; // Ignore vertical tilt
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f; // Ignore vertical tilt
        camRight.Normalize();

        // Calculate the movement direction relative to the camera
        Vector3 moveDirection = camForward * inputDirection.z + camRight * inputDirection.x;

        // Apply movement
        rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0);
    }
}
