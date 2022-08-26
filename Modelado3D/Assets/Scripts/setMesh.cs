// Joan Daniel Guerrero García
// Gerardo Reyes Lozano
// Alison Nicole Gallardo Zendejas

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMesh : MonoBehaviour
{
    struct Shape{
        public List<Vector3> vertices;
        public List<int> triangles;
    };

    void Tessellate(Shape input)
    {
        for(int t= 0; t < input.triangles.Count; t+=12)
        {
            Vector3 A = input.vertices[input.triangles[t+0]];
            Vector3 B = input.vertices[input.triangles[t+1]];
            Vector3 C = input.vertices[input.triangles[t+2]];
            Vector3 o = ((A+B)/2.0f).normalized;
            Vector3 p = ((B+C)/2.0f).normalized;
            Vector3 q = ((C+A)/2.0f).normalized;
            int ia = input.triangles[t+0];
            int ib = input.triangles[t+1];
            int ic = input.triangles[t+2];
            int io = FindVertex(input.vertices, o);
            int ip = FindVertex(input.vertices, p);
            int iq = FindVertex(input.vertices, q);
 
            if(io == -1)
            {
                input.vertices.Add(o);
                io = input.vertices.Count-1;
            }
            if(ip == -1)
            {
                input.vertices.Add(p);
                ip = input.vertices.Count-1;
            }
            if(iq == -1)
            {
                input.vertices.Add(q);
                iq = input.vertices.Count-1;
            }
            
            List<int> newT = new List<int>();
            for(int i = 0; i < t; i++)
                newT.Add(input.triangles[i]);
            newT.Add(ia); newT.Add(io); newT.Add(iq);
            newT.Add(io); newT.Add(ib); newT.Add(ip);
            newT.Add(iq); newT.Add(ip); newT.Add(ic);
            newT.Add(io); newT.Add(ip); newT.Add(iq);
            for(int i = t+3; i < input.triangles.Count; i++)
                newT.Add(input.triangles[i]);
            input.triangles.Clear();
            for(int i = 0; i < newT.Count; i++)
                input.triangles.Add(newT[i]);
        }
    }

    int FindVertex(List<Vector3> list, Vector3 vertice)
    {
        return list.IndexOf(vertice);
    }

    Mesh myMesh;
    void Start()
    {
        myMesh = new Mesh();

        SetOctaedro();
        //SetTriangle();
        //SetCube();

        myMesh.RecalculateNormals();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = new Material(Shader.Find("Diffuse"));
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = myMesh;
    }

    void SetTriangle()
    {
        Shape triangle = new Shape();
        triangle.vertices = new List<Vector3>{
            new Vector3(0, 0, 0),
            new Vector3(13, 0, 0),
            new Vector3(5, 12, 0)
        };
        triangle.triangles = new List<int>{0, 1, 2};

        Tessellate(triangle);

        myMesh.vertices = triangle.vertices.ToArray();
        myMesh.triangles = triangle.triangles.ToArray();
    }
    void SetCube()
    {
        Shape cube = new Shape();
        cube.vertices = new List<Vector3>(){
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),
            new Vector3(1, 1, 1),
            new Vector3(-1, 1, 1),
            new Vector3(1, -1, -1),
            new Vector3(1, 1, -1),
            new Vector3(-1, -1, -1),
            new Vector3(-1, 1, -1)
        };

        cube.triangles = new List<int>{
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

        myMesh.vertices = cube.vertices.ToArray();
        myMesh.triangles = cube.triangles.ToArray();
    }
    void SetOctaedro()
    {
        Shape octaedro = new Shape();
            octaedro.vertices = new List<Vector3>(){
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0),
            new Vector3(0, 0, -1),
            new Vector3(-1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0)
        };  
        
        octaedro.triangles = new List<int>(){   
            0, 1, 4, 
            1, 2, 4,
            2, 3, 4, 
            3, 0, 4,
    
            0, 5, 1,
            1, 5, 2,
            2, 5, 3,
            3, 5, 0
        };

        Tessellate(octaedro);
        Tessellate(octaedro);
        Tessellate(octaedro);
        myMesh.vertices = octaedro.vertices.ToArray();
        myMesh.triangles = octaedro.triangles.ToArray();
    }
}
