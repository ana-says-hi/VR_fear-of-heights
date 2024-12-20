using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_elevator : MonoBehaviour
{
    // public Transform elevator; // The elevator object to move
    // public Transform[] floors; // Array of floor positions (set in the inspector)
    // public float speed = 2f; // Speed of the elevator movement

    // private bool isMoving = false; // Is the elevator currently moving?
    // private Transform targetFloor; // Target floor to move to

    // public KeyCode[] floorKeys; // Array of keys corresponding to floors

    // public Transform camera;
    // public float playerActivationDistance;
    // bool active = false;

    // void Update()
    // {
    //     RaycastHit hit;
    //     active=Physics.Raycast(camera.position,camera.TransformDirection(Vector3.forward), out hit,playerActivationDistance);

    //     if(Input.GetKeyDown(KeyCode.F) && active==true)
    //         {
    //             hit.transform.GetComponent<Animator>().SetTrigger("Activate");
    //         }
    // }
    public GameObject textBubble; // Drag the text bubble here in the Inspector

    void Start()
    {
        if (textBubble != null)
            textBubble.SetActive(false); // Ensure the text is hidden initially
    }

    void Update()
    {
        // Cast a ray from the camera to detect what the player is looking at
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object being hit is this object
            if (hit.transform == transform)
            {
                if (textBubble != null)
                    textBubble.SetActive(true); // Show the text bubble
            }
            else
            {
                if (textBubble != null)
                    textBubble.SetActive(false); // Hide the text bubble
            }
        }
    }
}
