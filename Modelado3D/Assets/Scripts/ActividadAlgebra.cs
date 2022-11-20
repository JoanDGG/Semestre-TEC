using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActividadAlgebra : MonoBehaviour
{
    Vector4 a;
    Vector4 b;
    Vector4 c;
    void Start()
    {
        a = new Vector4(1, 2, 3, 1);
        Matrix4x4 t = Transformaciones.Translate(0, -3, 0);
        Matrix4x4 r = Transformaciones.RotateX(30);

        b = (r * t) * a;
        c = (t * r) * a;

        Debug.Log(b.ToString("F5"));
        Debug.Log(c.ToString("F5"));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(Vector3.zero, a, Color.white);
        Debug.DrawLine(Vector3.zero, b, Color.blue);
        Debug.DrawLine(Vector3.zero, c, Color.red);
    }
}
