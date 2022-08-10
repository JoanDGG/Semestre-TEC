using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalado : MonoBehaviour
{
    public Vector2 scaleMinMax = new Vector2(1f, 3f);
    public float scaleVelocity = 0.01f;
    private Vector3 scaleValues;

    void Start()
    {
        scaleValues = new Vector3(  gameObject.transform.localScale.x,
                                    gameObject.transform.localScale.y,
                                    gameObject.transform.localScale.z);
    }
    void Update()
    {
        ScaleSphere();
    }
    void ScaleSphere()
    {
        if(gameObject.transform.localScale.x > scaleMinMax.y)
        {
            scaleValues = -scaleVelocity * Vector3.one;
        }
        if (gameObject.transform.localScale.x < scaleMinMax.x)
        {
            scaleValues = scaleVelocity * Vector3.one;
        }
        gameObject.transform.localScale += scaleValues;
    }
}
