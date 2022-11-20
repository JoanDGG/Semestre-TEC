using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActividadAlgebra2 : MonoBehaviour
{
    void Start()
    {
        float side = 3.5f;
        float distance = side / 2.0f;
        List<Vector4> vertices = new List<Vector4>();
        vertices.Add(new Vector4(-distance, -distance, distance, 1));
        vertices.Add(new Vector4(distance, -distance, distance, 1));
        vertices.Add(new Vector4(distance, distance, distance, 1));
        vertices.Add(new Vector4(-distance, distance, distance, 1));
        vertices.Add(new Vector4(distance, -distance, -distance, 1));
        vertices.Add(new Vector4(-distance, -distance, -distance, 1));
        vertices.Add(new Vector4(distance, distance, -distance, 1));
        vertices.Add(new Vector4(-distance, distance, -distance, 1));

        foreach (Vector4 vertice in vertices)
        {
            Debug.Log(vertice.ToString("F5"));
        }
        Debug.Log("------------------------");

        Matrix4x4 rz = Transformaciones.RotateZ(-15.63f);
        Matrix4x4 t = Transformaciones.Translate(0, 0, 12.77f);
        Matrix4x4 ry = Transformaciones.RotateY(2.48f);

        List<Vector4> newVertices = new List<Vector4>();
        foreach (Vector4 vertice in vertices)
        {
            Vector4 position = rz * t * ry * vertice;
            newVertices.Add(position);
            Debug.Log(vertice.ToString("F5"));
        }
        
    }
}
