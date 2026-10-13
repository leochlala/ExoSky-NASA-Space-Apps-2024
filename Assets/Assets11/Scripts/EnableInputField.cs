using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.EventSystems;

public class TMPInputFieldToggle : MonoBehaviour, IPointerClickHandler
{
    public TMP_InputField myTMPInputField;  // Reference to the TMP_InputField

    // Static variable to track input field focus across other scripts
    public static bool inputFieldIsFocused = false;

    void Start()
    {
        if (myTMPInputField == null)
        {
            Debug.LogError("TMP_InputField is not assigned in TMPInputFieldToggle script.");
            return;
        }

        // Ensure the TMP_InputField is interactable initially if needed
        myTMPInputField.interactable = true;
    }

    // Triggered when the TMP_InputField is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (myTMPInputField == null) return;

        // Enable the TMP_InputField when clicked and set focus
        inputFieldIsFocused = true;
        myTMPInputField.ActivateInputField(); // Optional: Set focus to the TMP_InputField
    }

    void Update()
    {
        if (myTMPInputField == null) return;

        // Update the static boolean based on whether the input field is currently focused
        if (!myTMPInputField.isFocused)
        {
            inputFieldIsFocused = false; // Set the shared flag to false when focus is lost
        }
        else
        {
            inputFieldIsFocused = true;  // Set the shared flag to true when focused
        }
    }
}