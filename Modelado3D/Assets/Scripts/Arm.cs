using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
*  Autores:
*  Daniel Garcia Barajas        A01378688
*  Joan Daniel Guerrero Garcia  A01378052
*/ 

public class Arm : MonoBehaviour
{
    [Min(0.1f)] public float rotSpeed = 0.3f;
    GameObject cube1;
    GameObject cube2;
    GameObject cube3;
    Vector3[] vCube1;
    Vector3[] vCube2;
    Vector3[] vCube3;
    Matrix4x4 scale;
    Matrix4x4 cube1OriginPos;
    float rotZ;
    private bool movingUp;
    
    // Start is called before the first frame update
    void Start()
    {
        rotZ = 0f;
        movingUp = true;

        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        vCube1 = cube1.GetComponent<MeshFilter>().mesh.vertices;
        vCube2 = cube2.GetComponent<MeshFilter>().mesh.vertices;
        vCube3 = cube3.GetComponent<MeshFilter>().mesh.vertices;

        scale = Transformaciones.Scale(1f, 0.5f, 0.5f);
        cube1OriginPos = Transformaciones.Translate(0.5f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(rotZ <= 45 && movingUp)
            rotZ += rotSpeed;
        if(rotZ >= -45 && !movingUp)
            rotZ -= rotSpeed;

        if(rotZ > 45)
            movingUp = false;
        if(rotZ < -45)
            movingUp = true;
        
        Matrix4x4 rotarZ = Transformaciones.RotateZ(rotZ);
        
        // Cubo 1
        Vector3 pivote1 = new Vector3(cube1OriginPos[0] - 0.5f, 0f, 0f);
        Matrix4x4 pivotePosicion = Transformaciones.Translate(pivote1.x, pivote1.y, pivote1.z);
        Matrix4x4 newPosicion = Transformaciones.Translate(-pivote1.x, pivote1.y, pivote1.z);
        Matrix4x4 rotarPivote = newPosicion * rotarZ * pivotePosicion * cube1OriginPos;

        cube1.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(rotarPivote * scale, vCube1);
        
        // Cubo 2
        Vector3 pivote2 = new Vector3(cube1.transform.position.x + 0.5f, 0f, 0f);
        Matrix4x4 pivotePosicion2 = Transformaciones.Translate(pivote2.x + 0.5f, pivote2.y, pivote2.z);
        Matrix4x4 newPosicion2 = Transformaciones.Translate(-pivote2.x + 0.5f, pivote2.y, pivote2.z);
        Matrix4x4 rotarPivote2 = newPosicion2 * rotarZ * pivotePosicion2 * rotarPivote;

        cube2.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(rotarPivote2 * scale, vCube2);

        // Cubo 3
        Vector3 pivote3 = new Vector3(cube2.transform.position.x + 0.5f, 0f, 0f);
        Matrix4x4 pivotePosicion3 = Transformaciones.Translate(pivote3.x + 0.5f, pivote3.y, pivote3.z);
        Matrix4x4 newPosicion3 = Transformaciones.Translate(-pivote3.x + 0.5f, pivote3.y, pivote3.z);
        Matrix4x4 rotarPivote3 = newPosicion3 * rotarZ * pivotePosicion3 * rotarPivote2;

        cube3.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(rotarPivote3 * scale, vCube3);
    }
}
