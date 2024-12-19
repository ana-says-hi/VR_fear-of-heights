using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_elevator : MonoBehaviour
{
   public Transform elevator; // The elevator object to move
    public Transform[] floors; // Array of floor positions (set in the inspector)
    public float speed = 2f; // Speed of the elevator movement

    private bool isMoving = false; // Is the elevator currently moving?
    private Transform targetFloor; // Target floor to move to

    public KeyCode[] floorKeys; // Array of keys corresponding to floors

    void Update()
    {
        // Check for input to activate floors
        for (int i = 0; i < floorKeys.Length; i++)
        {
            if (Input.GetKeyDown(floorKeys[i]))
            {
                MoveToFloor(i);
            }
        }

        // Move the elevator if it is in motion
        if (isMoving && targetFloor != null)
        {
            elevator.position = Vector3.MoveTowards(elevator.position, targetFloor.position, speed * Time.deltaTime);

            // Stop moving if the elevator has reached the target floor
            if (Vector3.Distance(elevator.position, targetFloor.position) < 0.01f)
            {
                isMoving = false;
                targetFloor = null;
            }
        }
    }

    // This method is called when a floor button is pressed
    public void MoveToFloor(int floorIndex)
    {
        if (floorIndex < 0 || floorIndex >= floors.Length)
        {
            Debug.LogError("Invalid floor index: " + floorIndex);
            return;
        }

        if (!isMoving)
        {
            targetFloor = floors[floorIndex];
            isMoving = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect trigger collisions for physical buttons
        for (int i = 0; i < floors.Length; i++)
        {
            if (other.gameObject.name == $"Button_Floor_{i + 1}")
            {
                MoveToFloor(i);
            }
        }
    }
}
