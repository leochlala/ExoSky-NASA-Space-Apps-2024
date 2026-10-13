using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitLines : MonoBehaviour
{
    public Transform centerObject;         
    public float semiMajorAxis = 5f;       
    public float semiMinorAxis = 3f;       
    public int segments = 100;             

    public float lineWidth = 0.1f;         
    public Color lineColor = Color.white;  

    private LineRenderer lineRenderer;
    private bool isOrbitLineVisible = false;  

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        
        lineRenderer.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOrbitLineVisible)
            {
                HideOrbitLine();
            }
            else
            {
                ShowOrbitLine();
            }
        }
    }

    
    void ShowOrbitLine()
    {
        isOrbitLineVisible = true;
        lineRenderer.enabled = true;  
        DrawOrbit();
    }

    
    void HideOrbitLine()
    {
        isOrbitLineVisible = false;
        lineRenderer.enabled = false;  
    }

    void DrawOrbit()
    {
        float angleStep = 360f / segments;
        Vector3[] positions = new Vector3[segments + 1];

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * semiMajorAxis;
            float z = Mathf.Sin(angle) * semiMinorAxis;
            positions[i] = new Vector3(x, 0, z) + centerObject.position;
        }

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

    void OnValidate()
    {
        if (lineRenderer != null && isOrbitLineVisible)
        {
            DrawOrbit();
        }
    }
}
