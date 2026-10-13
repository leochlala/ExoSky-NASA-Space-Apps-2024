using System.Collections;
using UnityEngine;

public class EllipticalOrbit : MonoBehaviour
{
    public Transform centerObject;  
    
    
    public float semiMajorAxis = 10.0f;  
    public float semiMinorAxis = 5.0f;   
    public float orbitSpeed = 1.0f;     

    private bool isOrbiting = false;     
    private float orbitTime;            
    private Coroutine orbitCoroutine;    

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOrbiting)
            {
                StopOrbit();
            }
            else
            {
                StartOrbit();
            }
        }
    }

    
    public void StartOrbit()
    {
        if (orbitCoroutine == null)  
        {
            isOrbiting = true;
            orbitCoroutine = StartCoroutine(OrbitAroundCenter());
        }
    }

    
    public void StopOrbit()
    {
        if (orbitCoroutine != null)  
        {
            StopCoroutine(orbitCoroutine);
            orbitCoroutine = null;
            isOrbiting = false;
        }
    }

    
    private IEnumerator OrbitAroundCenter()
    {
        while (true)  
        {
            
            orbitTime += Time.deltaTime * orbitSpeed;

            
            float x = semiMajorAxis * Mathf.Cos(orbitTime);  
            float z = semiMinorAxis * Mathf.Sin(orbitTime);  

            
            Vector3 newPosition = new Vector3(x, 0, z) + centerObject.position;

            transform.position = newPosition;

            yield return null;  
        }
    }
}
