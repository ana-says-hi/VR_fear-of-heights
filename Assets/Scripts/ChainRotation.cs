using UnityEngine;

public class ChainRotation : MonoBehaviour
{
    // Rotation speed for each segment
    public float rotationSpeed = 50f;

    // Array of chain segments
    public Transform[] chainSegments;

    void Update()
    {
        // Rotate each segment around its parent's local X-axis
        for (int i = 0; i < chainSegments.Length; i++)
        {
            Transform currentSegment = chainSegments[i];

            if (currentSegment.parent != null)
            {
                // Rotate the current segment **only** around its parent's X-axis (local space)
                currentSegment.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
