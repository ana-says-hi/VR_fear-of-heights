using UnityEngine;

public class WASD_movement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Speed of smooth movement
    public float stepDistance = 1f;    // Distance the camera moves with each step

    public Vector3 minBounds;          // Minimum boundaries for movement
    public Vector3 maxBounds;          // Maximum boundaries for movement

    private Vector3 targetPosition;    // Target position for smooth movement

    void Start()
    {
        // Initialize the starting target position as the current position
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleMovement();
        SmoothMovement();
    }

    void HandleMovement()
    {
        // Update target position on key press (WASD or Arrow Keys)
        if (Input.GetKeyDown(KeyCode.W)) targetPosition += transform.forward * stepDistance;
        if (Input.GetKeyDown(KeyCode.S)) targetPosition -= transform.forward * stepDistance;
        if (Input.GetKeyDown(KeyCode.A)) targetPosition -= transform.right * stepDistance;
        if (Input.GetKeyDown(KeyCode.D)) targetPosition += transform.right * stepDistance;

        // Clamp the target position within bounds
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);
        targetPosition.z = Mathf.Clamp(targetPosition.z, minBounds.z, maxBounds.z);
    }

    void SmoothMovement()
    {
        // Smoothly move towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
