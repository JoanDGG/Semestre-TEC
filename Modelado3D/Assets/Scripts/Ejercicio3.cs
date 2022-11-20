using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio3 : MonoBehaviour
{
    GameObject cube1;
    GameObject cube2;
    Vector3[] vCube1;
    Vector3[] vCube2;
    float rotZ;
    // Start is called before the first frame update
    void Start()
    {
        rotZ = 0f;
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        vCube1 = cube1.GetComponent<MeshFilter>().mesh.vertices;
        cube1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
        vCube2 = cube2.GetComponent<MeshFilter>().mesh.vertices;
        cube2.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        rotZ += 0.1f;
        Matrix4x4 cube1Pos = Transformaciones.Translate(1.84f, 1.659f, 0f);
        Matrix4x4 cube2Pos = Transformaciones.Translate(3.83f, 1.659f, 0f);
        cube1.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(cube1Pos, vCube1);
        cube2.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(cube2Pos, vCube2);

        Matrix4x4 cubeCenter = Transformaciones.Translate(-1.84f, -1.659f, 0f);
        Matrix4x4 rotarZ = Transformaciones.RotateZ(rotZ);
        Matrix4x4 cubeOrigin = cube1Pos;

        Matrix4x4 rotarPivote = cubeOrigin * rotarZ * cubeCenter * cube2Pos;
        cube2.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(rotarPivote, vCube2);
    }
}
