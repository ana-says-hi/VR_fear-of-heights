using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform elevator;            // The elevator GameObject's Transform
    public Transform[] floors;           // An array of floor positions (e.g., Floor1, Floor2, Floor3)
    public float speed = 5f;             // Speed
    private bool isMoving = false;       
    private Transform targetFloor;       

    private void Start()
    {
        GameObject floorsParent = GameObject.Find("Floors"); // parent "Floors"
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
        for(int i=0;i<=7;i++)
            if(Input.GetKeyDown(KeyCode.Alpha1+i))
                MoveElevatorToFloor(i);


        if (Input.GetKeyDown(KeyCode.Space) && isMoving)
        {
            isMoving = false;
            Debug.Log("Elevator stopped.");
        }

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
