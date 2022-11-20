using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube
{
    public GameObject cube;
    public Vector3 position;

    public Cube(GameObject _cube, Vector3 _position)
    {
        this.cube = _cube;
        this.position = _position;
    }
}
public class Ejercicio4 : MonoBehaviour
{
    [Min(0.1f)] public float rotSpeed;
    private List<Cube> cubes;
    private Vector3[] origin;
    private List<Matrix4x4> matrices;
    private List<Matrix4x4> mOriginales;
    private float rotY;
    private float rotZ;
    void Start()
    {
        rotY = 0f;
        rotZ = 0f;
        cubes = new List<Cube>();
        matrices = new List<Matrix4x4>();
        mOriginales = new List<Matrix4x4>();

        for (int i = 0; i < 8; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubes.Add(new Cube(cube, Vector3.zero));
        }
        
        cubes[0].position.Set(-0.5f, -0.5f, 0.5f);
        cubes[1].position.Set(0.5f, -0.5f, 0.5f);
        cubes[2].position.Set(0.5f, 0.5f, 0.5f);
        cubes[3].position.Set(-0.5f, 0.5f, 0.5f);
        cubes[4].position.Set(-0.5f, -0.5f, -0.5f);
        cubes[5].position.Set(0.5f, -0.5f, -0.5f);
        cubes[6].position.Set(0.5f, 0.5f, -0.5f);
        cubes[7].position.Set(-0.5f, 0.5f, -0.5f);

        origin = cubes[0].cube.GetComponent<MeshFilter>().mesh.vertices;

        for (int i = 0; i < 8; i++)
        {
            mOriginales.Add(Transformaciones.Translate(cubes[i].position.x, cubes[i].position.y, cubes[i].position.z));
            matrices.Add(mOriginales[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rotZ < 360)
        {
            rotZ += rotSpeed;
            for (int i = 4; i < 8; i++)
                matrices[i] = Transformaciones.RotateZ(rotZ) * mOriginales[i];
        }
        else if(rotY < 360)
        {
            rotY += rotSpeed;
            matrices[2] = Transformaciones.RotateY(rotY) * mOriginales[2];
            matrices[3] = Transformaciones.RotateY(rotY) * mOriginales[3];
            matrices[6] = Transformaciones.RotateY(rotY) * mOriginales[6];
            matrices[7] = Transformaciones.RotateY(rotY) * mOriginales[7];
        }
        else
        {
            rotZ = rotY = 0f;
        }
        
        
        for (int i = 0; i < 8; i++)
            cubes[i].cube.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(matrices[i], origin);
    }
}