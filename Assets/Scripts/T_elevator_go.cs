using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_elevator_go : MonoBehaviour
{
    Vector3[] locations;
    float speed = 3;
    Vector3 target;
    float stopDistanceThreshold = 0.01f; // Tolerance for stopping
    bool isMoving = true; // Controls if the elevator is moving

    // Start is called before the first frame update
    void Start()
    {
        int count = 5;
        locations = new Vector3[count];
        Vector3 startPos = transform.position;

        // Generate vertical positions for the elevator
        for (int i = 0; i < count; i++)
        {
            float yValue = 0.5f + (i * 5f); // Vertical positions
            locations[i] = startPos + new Vector3(0, yValue, 0);
        }

        ChooseRandomTarget(); // Set initial target
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move towards the current target
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Check if the elevator is close enough to the target
            if (Vector3.Distance(transform.position, target) <= stopDistanceThreshold)
            {
                // Stop movement and start the delay coroutine
                isMoving = false;
                StartCoroutine(ChangeTargetAfterDelay(3f));
            }
        }
    }

    void ChooseRandomTarget()
    {
        int randomIndex = Random.Range(0, locations.Length);
        target = locations[randomIndex]; // Assign to the class-level 'target'
    }

    IEnumerator ChangeTargetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ChooseRandomTarget(); // Choose a new target after the delay
        isMoving = true; // Resume movement
    }
}
