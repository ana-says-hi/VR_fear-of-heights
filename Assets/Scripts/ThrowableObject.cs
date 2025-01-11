using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public GameObject objectToThrow; // The prefab to be thrown
    public float throwForce = 10f; // The force applied to the object when thrown
    public Transform spawnPoint; // Optional spawn point for the object (defaults to camera)

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

        rb.velocity = spawnTransform.forward * throwForce; // Set velocity for consistent movement
        // Alternative to velocity: Use AddForce if you want an "impulse" effect
        // rb.AddForce(spawnTransform.forward * throwForce, ForceMode.Impulse);

        // Destroy the thrown object after 5 seconds to avoid clutter
        Destroy(thrownObject, 5f);
    }
}
