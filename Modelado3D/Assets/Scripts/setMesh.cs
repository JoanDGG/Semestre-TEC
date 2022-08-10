// Joan Daniel Guerrero García
// Gerardo Reyes Lozano
// Alison Nicole Gallardo Zendejas

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMesh : MonoBehaviour
{
    struct Shape{
        public Vector3[] vertices;
        public int[] triangles;
    };

    Shape Tessellate(Shape input)
    {
        Vector3[] verticesI = input.vertices;
        int[] trianglesI = input.triangles;
        Vector3 A = verticesI[0];
        Vector3 B = verticesI[1];
        Vector3 C = verticesI[2];
        Vector3 AB = (A + B)/2;
        Vector3 AC = (A + C)/2;
        Vector3 BC = (B + C)/2;
        Vector3[] verticesO = new Vector3[6]{ A, B, C, AB, BC, AC };
        int[] trianglesO = new int[12]{ 0, 3, 5, 3, 1, 4, 5, 4, 2, 3, 4, 5 };
        Shape newShape = new Shape();
        newShape.vertices = verticesO;
        newShape.triangles = trianglesO;
        return newShape;
    }

    Mesh myMesh;
    
    void Start()
    {
        myMesh = new Mesh();
        //SetTriangle();
        //SetCube();
        SetOctaedro();

        myMesh.RecalculateNormals();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = new Material(Shader.Find("Diffuse"));
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = myMesh;
    }

    void SetTriangle()
    {
        Shape triangle = new Shape();
        triangle.vertices = new Vector3[3]{
            new Vector3(0, 0, 0),
            new Vector3(12, 0, 0),
            new Vector3(5, 12, 0)
        };
        triangle.triangles = new int[3]{0, 1, 2};

        Shape newTriangle = Tessellate(triangle);

        myMesh.vertices = newTriangle.vertices;
        myMesh.triangles = newTriangle.triangles;
    }
    void SetCube()
    {
        Vector3[] newVertices = new Vector3[8];
        newVertices[0] = new Vector3(-1, -1, 1);
        newVertices[1] = new Vector3(1, -1, 1);
        newVertices[2] = new Vector3(1, 1, 1);
        newVertices[3] = new Vector3(-1, 1, 1);
        newVertices[4] = new Vector3(1, -1, -1);
        newVertices[5] = new Vector3(1, 1, -1);
        newVertices[6] = new Vector3(-1, -1, -1);
        newVertices[7] = new Vector3(-1, 1, -1);
        
        int[] newTriangles = new int[]{
            0, 1, 2,
            0, 2, 3,
            1, 4, 5,
            1, 5, 2,
            4, 6, 7,
            4, 7, 5,
            6, 0, 3,
            6, 3, 7,
            3, 2, 5,
            3, 5, 7,
            1, 0, 6,
            1, 6, 4
        };

        myMesh.vertices = newVertices;
        myMesh.triangles = newTriangles;
    }
    void SetOctaedro()
    {
        Shape octaedro = new Shape();
        octaedro.vertices = new Vector3[6]{
            new Vector3(1, 0, 0),
            new Vector3(0, 0, -1),
            new Vector3(-1, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0)
        };
        
        octaedro.triangles = new int[]{
            0, 1, 4,
            1, 2, 4,
            2, 3, 4,
            3, 0, 4,
            5, 1, 0,
            5, 2, 1,
            5, 3, 2,
            5, 0, 3
        };

        myMesh.vertices = octaedro.vertices;
        myMesh.triangles = octaedro.triangles;
    }
}
