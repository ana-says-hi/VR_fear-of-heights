using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform elevator;            // The elevator GameObject's Transform
    public Transform[] floors;           // An array of floor positions (e.g., Floor1, Floor2, Floor3)
    public float speed = 2f;             // Speed of elevator movement
    private bool isMoving = false;       // Tracks if the elevator is currently moving
    private Transform targetFloor;       // The floor the elevator is moving toward

    private void Start()
    {
        // Automatically assign the floors by finding the child objects of the "Floors" GameObject
        GameObject floorsParent = GameObject.Find("Floors"); // Ensure your parent is named "Floors"
        if (floorsParent != null)
        {
            int childCount = floorsParent.transform.childCount;
            floors = new Transform[childCount];

            for (int i = 0; i < childCount; i++)
            {
                floors[i] = floorsParent.transform.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("Floors GameObject not found in the scene!");
        }
    }

    private void Update()
    {
        // Check for number key presses and set target floor
        if (Input.GetKeyDown(KeyCode.Alpha1)) MoveElevatorToFloor(0); // Floor1
        if (Input.GetKeyDown(KeyCode.Alpha2)) MoveElevatorToFloor(1); // Floor2
        if (Input.GetKeyDown(KeyCode.Alpha3)) MoveElevatorToFloor(2); // Floor3
        // Add more floors if needed

        // Move the elevator if it's currently moving
        if (isMoving && targetFloor != null)
        {
            // Smoothly move the elevator toward the target floor
            elevator.position = Vector3.MoveTowards(elevator.position, targetFloor.position, speed * Time.deltaTime);

            // Check if the elevator has reached the target floor
            if (Vector3.Distance(elevator.position, targetFloor.position) < 0.01f)
            {
                isMoving = false;
                Debug.Log("Elevator reached floor!");
            }
        }
    }

    private void MoveElevatorToFloor(int floorIndex)
    {
        if (isMoving)
        {
            Debug.Log("Elevator is already moving.");
            return;
        }

        if (floorIndex < 0 || floorIndex >= floors.Length)
        {
            Debug.LogError("Invalid floor index!");
            return;
        }

        // Set the target floor and start moving
        targetFloor = floors[floorIndex];
        isMoving = true;
    }
}
