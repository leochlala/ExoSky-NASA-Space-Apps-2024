using UnityEngine;
using UnityEngine.UI;

public class ConstellationUIManager : MonoBehaviour
{
    public VerticalLayoutGroup constellationListLayout;   // Reference to the Vertical Layout Group
    public GameObject constellationButtonPrefab;          // Prefab for the constellation button
    public int maxConstellations = 5;                     // Maximum number of allowed constellations

    private void Start()
    {
        // Check for missing references
        if (constellationListLayout == null)
        {
            Debug.LogError("Constellation List Layout is not assigned in the Inspector!");
            return;
        }

        if (constellationButtonPrefab == null)
        {
            Debug.LogError("Constellation Button Prefab is not assigned in the Inspector!");
            return;
        }
    }

    // This method should be called when the user submits a new constellation name
    public void AddConstellationUI(string constellationName)
    {
        // Check if the maximum limit has been reached
        int currentCount = constellationListLayout.transform.childCount;
        Debug.Log($"Attempting to add constellation: {constellationName}");
        Debug.Log($"Current number of constellations in layout: {currentCount} (Limit: {maxConstellations})");

        if (currentCount >= maxConstellations)
        {
            Debug.LogWarning("Cannot add more constellations. Maximum number reached.");
            return;
        }

        // Instantiate a new button for the constellation and set its name
        GameObject newButton = Instantiate(constellationButtonPrefab, constellationListLayout.transform);
        newButton.GetComponentInChildren<Text>().text = constellationName;

        Debug.Log($"Constellation '{constellationName}' button added. Total constellations now: {currentCount + 1}");

        // Optionally, add listeners or other functionality to the button
        newButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log($"Constellation '{constellationName}' selected.");
        });
    }
}