using UnityEngine;

public class TelescopeInteraction : MonoBehaviour
{
    public GameObject telescopeCamera; 
    public GameObject playerCamera; 
    public GameObject telescopeObject; 
    private MeshRenderer[] telescopeRenderers; 
    private bool isInTelescopeView = false; 
    public float zoomSpeed = 10f; 
    public float maxZoom = 20f; 
    public float minZoom = 60f; 

    private Camera telescopeCam; 

    void Start()
    {
        telescopeCam = telescopeCamera.GetComponent<Camera>(); 
        
        
        telescopeRenderers = telescopeObject.GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.LeftControl))
        {
            ToggleTelescopeView();
        }

        
        if (isInTelescopeView)
        {
           
            HandleZoom();
        }
    }

    void ToggleTelescopeView()
    {
        isInTelescopeView = !isInTelescopeView; 
        telescopeCamera.SetActive(isInTelescopeView); 
        playerCamera.SetActive(!isInTelescopeView); 

        
        foreach (var renderer in telescopeRenderers)
        {
            renderer.enabled = !isInTelescopeView;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        
        float zoomFactor = scroll * zoomSpeed;

        
        telescopeCam.fieldOfView = Mathf.Clamp(telescopeCam.fieldOfView - zoomFactor, maxZoom, minZoom);
    }
}
