using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public Vector3 rotateValues = new Vector3(1f, 0f, 3f);

    void Update()
    {
        RotateSphere();
    }
    void RotateSphere()
    {
        //gameObject.transform.localRotation = Quaternion.Euler(rotateValues.x * Time.deltaTime, rotateValues.y * Time.deltaTime, rotateValues.z * Time.deltaTime);
        gameObject.transform.Rotate(rotateValues.x, rotateValues.y, rotateValues.z, Space.Self);
    }
}
