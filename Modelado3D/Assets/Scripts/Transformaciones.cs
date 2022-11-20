using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformaciones
{
    public static Matrix4x4 Translate(float x, float y, float z)
    {
        Matrix4x4 t = Matrix4x4.identity;
        t[0,3] = x;
        t[1,3] = y;
        t[2,3] = z;
        return t;
    }
    public static Matrix4x4 Scale(float x, float y, float z)
    {
        Matrix4x4 t = Matrix4x4.identity;
        t[0,0] = x;
        t[1,1] = y;
        t[2,2] = z;
        return t;
    }
    public static Matrix4x4 RotateX(float a)
    {
        Matrix4x4 t = Matrix4x4.identity;
        float radA = Mathf.Deg2Rad * a;
        t[1,1] = Mathf.Cos(radA);
        t[1,2] = -Mathf.Sin(radA);
        t[2,1] = Mathf.Sin(radA);
        t[2,2] = Mathf.Cos(radA);
        return t;
    }
    public static Matrix4x4 RotateY(float a)
    {
        Matrix4x4 t = Matrix4x4.identity;
        float radA = Mathf.Deg2Rad * a;
        t[0,0] = Mathf.Cos(radA);
        t[0,2] = Mathf.Sin(radA);
        t[2,0] = -Mathf.Sin(radA);
        t[2,2] = Mathf.Cos(radA);
        return t;
    }
    public static Matrix4x4 RotateZ(float a)
    {
        Matrix4x4 t = Matrix4x4.identity;
        float radA = Mathf.Deg2Rad * a;
        t[0,0] = Mathf.Cos(radA);
        t[0,1] = -Mathf.Sin(radA);
        t[1,0] = Mathf.Sin(radA);
        t[1,1] = Mathf.Cos(radA);
        return t;
    }

    public static Vector3[] Transform(Matrix4x4 m, Vector3[] vs)
    {
        // Para almacenar la coleccion de vertices transformados
        Vector3[] newVerts = new Vector3[vs.Length];
        // Recorremos cada vertice
        for (int v = 0; v < vs.Length; v++)
        {
            Vector3 vi = vs[v];
            // Creamos un vector homogeneo, con w, de tamaño 4
            Vector4 newV = new Vector4(vi.x, vi.y, vi.z, 1);
            // Aplicamos la transformacion mediante un producto
            newV = m * newV;
            // Almacenamos el nuevo vector transformado: Vector3 = Vector4
            newVerts[v] = newV;
        }
        return newVerts;
    }
}
