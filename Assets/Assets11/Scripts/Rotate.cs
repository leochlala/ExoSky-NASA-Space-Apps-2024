using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;  
    public float speed = 10f; 
    public Vector3 rotationAxis = Vector3.up; 

    void Update()
    {
        
        transform.RotateAround(target.transform.position, rotationAxis, speed * Time.deltaTime);
    }

    
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetRotationAxis(Vector3 newAxis)
    {
        rotationAxis = newAxis;
    }
}