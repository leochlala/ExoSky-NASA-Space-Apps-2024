using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConstellationCreator : MonoBehaviour
{
    public Material lineMaterial;
    public float lineWidth = 0.05f;
    public TMP_InputField constellationNameInput;
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    public TMP_Text constellationModeText;

    public int maxConstellations = 5;

    private List<Vector3> starPositions = new List<Vector3>();
    private LineRenderer lineRenderer;
    private bool constellationMode = false;

    [System.Serializable]
    public class Constellation
    {
        public string name;
        public List<Vector3> starPositions;

        public Constellation(string name, List<Vector3> positions)
        {
            this.name = name;
            this.starPositions = new List<Vector3>(positions);
        }
    }

    private List<Constellation> savedConstellations = new List<Constellation>();
    private Dictionary<string, bool> activeConstellations = new Dictionary<string, bool>();

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 0;
        UpdateConstellationModeText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.LeftControl))
        {
            constellationMode = !constellationMode;
            UpdateConstellationModeText();
        }

        if (Input.GetKeyDown(KeyCode.V) && Input.GetKey(KeyCode.LeftControl))
        {
            ResetConstellation();
        }

        if (constellationNameInput.isFocused) return;

        if (constellationMode && Input.GetMouseButtonDown(0))
        {
            HandleStarSelection();
        }

        if (Input.GetKeyDown(KeyCode.Return) && starPositions.Count > 0)
        {
            SaveConstellation();
        }

        HandleCameraMovement();
    }

    void HandleCameraMovement()
    {
        float moveSpeed = 5f;
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void HandleStarSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Star"))
            {
                Vector3 clickedPosition = hit.transform.position;
                starPositions.Add(clickedPosition);
                lineRenderer.positionCount = starPositions.Count;
                lineRenderer.SetPosition(starPositions.Count - 1, clickedPosition);
            }
        }
    }

    void SaveConstellation()
    {
        if (savedConstellations.Count >= maxConstellations) return;

        string constellationName = constellationNameInput.text;

        if (string.IsNullOrEmpty(constellationName) || constellationName.Contains(" ")) return;

        if (savedConstellations.Exists(c => c.name == constellationName)) return;

        Constellation newConstellation = new Constellation(constellationName, starPositions);
        savedConstellations.Add(newConstellation);

        ResetDrawing();
        UpdateConstellationDisplay();
    }

    void ResetDrawing()
    {
        starPositions.Clear();
        lineRenderer.positionCount = 0;
    }

    void ResetConstellation()
    {
        starPositions.Clear();
        lineRenderer.positionCount = 0;

        savedConstellations.Clear();
        activeConstellations.Clear();
        UpdateConstellationDisplay();
    }

    private void UpdateConstellationDisplay()
    {
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var constellation in savedConstellations)
        {
            GameObject button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TMP_Text>().text = constellation.name;
            button.GetComponent<Button>().onClick.AddListener(() => ToggleConstellation(constellation));
        }
    }

    private void ToggleConstellation(Constellation constellation)
    {
        if (activeConstellations.ContainsKey(constellation.name) && activeConstellations[constellation.name])
        {
            RemoveConstellation();
            activeConstellations[constellation.name] = false;
        }
        else
        {
            RecreateConstellation(constellation);
            activeConstellations[constellation.name] = true;
        }
    }

    private void RecreateConstellation(Constellation constellation)
    {
        ResetDrawing();
        starPositions = new List<Vector3>(constellation.starPositions);
        lineRenderer.positionCount = starPositions.Count;

        for (int i = 0; i < starPositions.Count; i++)
        {
            lineRenderer.SetPosition(i, starPositions[i]);
        }
    }

    private void RemoveConstellation()
    {
        ResetDrawing();
    }

    public void DeleteConstellation(string constellationName)
    {
        savedConstellations.RemoveAll(c => c.name == constellationName);
        activeConstellations.Remove(constellationName);
        UpdateConstellationDisplay();
    }

    private void UpdateConstellationModeText()
    {
        if (constellationModeText != null)
        {
            constellationModeText.text = "Constellation Mode: " + (constellationMode ? "On" : "Off");
        }
    }
}