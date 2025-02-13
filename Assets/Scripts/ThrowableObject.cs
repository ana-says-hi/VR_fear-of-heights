using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public GameObject objectToThrow; // The prefab to be thrown
    public float throwForce = 10f;  // The force applied to the object when thrown
    public Transform spawnPoint;   // Optional spawn point for the object (defaults to camera)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        if (objectToThrow == null)
        {
            Debug.LogError("No object assigned to throw!");
            return;
        }

        // Determine the spawn point (default to camera position if none is set)
        Transform spawnTransform = spawnPoint != null ? spawnPoint : Camera.main.transform;

        // Offset the spawn point slightly forward to avoid spawning inside the camera
        Vector3 spawnPosition = spawnTransform.position + spawnTransform.forward * 1f;

        // Instantiate the object to throw
        GameObject thrownObject = Instantiate(objectToThrow, spawnPosition, spawnTransform.rotation);

        // Apply a forward force to the object, using the camera's forward direction
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("The object to throw must have a Rigidbody component!");
            Destroy(thrownObject); // Destroy the object if it doesn't have Rigidbody
            return;
        }

        // Set velocity for consistent movement
        rb.velocity = spawnTransform.forward * throwForce;

        // Set collision detection mode to Continuous (to prevent tunneling)
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Optionally add this line to make the object stop moving on collision:
        // rb.drag = 1f;  // You can experiment with the drag to make the object slow down when colliding

        // Destroy the thrown object after 5 seconds to avoid clutter
        Destroy(thrownObject, 5f);
    }

    // Debugging: Log when the object collides with something
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }
}
