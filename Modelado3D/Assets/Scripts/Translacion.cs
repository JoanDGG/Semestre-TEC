using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translacion : MonoBehaviour
{
    public Vector3 translateOrigin = new Vector3(1f, 3f, 0f);
    public Vector3 translateEnd = new Vector3(5f, 1f, 2f);
    public float translateVelocity = 0.01f;
    private Vector3 translateValuesX;
    private Vector3 translateValuesY;
    private Vector3 translateValuesZ;
    private Vector3 translateBools = Vector3.one;

    void Start()
    {
        translateValuesX = new Vector3(gameObject.transform.localPosition.x, 0f, 0f);
        translateValuesY = new Vector3(0f, gameObject.transform.localPosition.y, 0f);
        translateValuesZ = new Vector3(0f, 0f, gameObject.transform.localPosition.z);
    }
    void Update()
    {
        TranslateSphere();
    }
    void TranslateSphere()
    {
        if (gameObject.transform.localPosition.x <= translateOrigin.x) { translateValuesX = new Vector3(translateVelocity, 0f, 0f); }
        else if (gameObject.transform.localPosition.x >= translateEnd.x) { translateValuesX = new Vector3(-translateVelocity, 0f, 0f); }
        
        if (gameObject.transform.localPosition.y <= translateOrigin.y) { translateValuesY = new Vector3(0f, translateVelocity, 0f); }
        else if (gameObject.transform.localPosition.y >= translateEnd.y) { translateValuesY = new Vector3(0f, -translateVelocity, 0f); }
        
        if (gameObject.transform.localPosition.z <= translateOrigin.z) { translateValuesZ = new Vector3(0f, 0f, translateVelocity); }
        else if (gameObject.transform.localPosition.z >= translateEnd.z) { translateValuesZ = new Vector3(0f, 0f, -translateVelocity); }
        
        gameObject.transform.localPosition += translateValuesX + translateValuesY + translateValuesZ;
    }
}
