using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_button : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel
    public Text optionsText; // Text to display options (or TextMeshProUGUI for TMP)
    public string[] floorOptions = { "Floor 3", "Floor 7", "Floor 12" }; // List of floors
    private int currentOptionIndex = 0; // Track the current option
    private bool isNearControlPanel = false; // Check if the player is near

    void Update()
    {
        // If the player is near the control panel
        if (isNearControlPanel)
        {
            // Scroll through options using up/down arrow keys or mouse wheel
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ScrollOptions(-1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ScrollOptions(1);
            }

            // Select the current option using the "F" key
            if (Input.GetKeyDown(KeyCode.F))
            {
                SelectOption();
            }
        }
    }

    void ScrollOptions(int direction)
    {
        currentOptionIndex = (currentOptionIndex + direction + floorOptions.Length) % floorOptions.Length;
        UpdateOptionsText();
    }

    void UpdateOptionsText()
    {
        // Highlight the current option
        string optionsDisplay = "";
        for (int i = 0; i < floorOptions.Length; i++)
        {
            if (i == currentOptionIndex)
            {
                optionsDisplay += $"> {floorOptions[i]} <\n"; // Highlighted option
            }
            else
            {
                optionsDisplay += $"{floorOptions[i]}\n";
            }
        }

        optionsText.text = optionsDisplay;
    }

    void SelectOption()
    {
        Debug.Log($"Selected: {floorOptions[currentOptionIndex]}");
        // Add logic to move the elevator to the selected floor
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Main Camera"))
        {
            isNearControlPanel = true;
            uiPanel.SetActive(true);
            UpdateOptionsText();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Main Camera"))
        {
            isNearControlPanel = false;
            uiPanel.SetActive(false);
        }
    }

}
