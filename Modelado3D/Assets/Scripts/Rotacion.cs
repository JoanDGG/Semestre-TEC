using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public Vector3 rotateValues = new Vector3(1f, 0f, 3f);
    public Transform pivot;
    public Vector3 axis = new Vector3(0, 1, 0);
    public float rotateVelocity = 1f;


    void Update()
    {
        RotateSphere();
        
        if(pivot != null)
            RotateAroundSphere();
    }
    void RotateSphere()
    {
        gameObject.transform.Rotate(rotateValues.x, rotateValues.y, rotateValues.z, Space.Self);
    }
    void RotateAroundSphere()
    {
        gameObject.transform.RotateAround(pivot.position, axis, rotateVelocity);
    }
}
