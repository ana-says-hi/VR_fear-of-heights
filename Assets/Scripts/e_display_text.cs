using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_elevator : MonoBehaviour
{
    public GameObject textBubble;

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
