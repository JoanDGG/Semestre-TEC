using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio2 : MonoBehaviour
{
    public float rotGlobalSpeed = 0.1f;
    private float rotY;
    private GameObject sun;
    private GameObject mercury;
    private GameObject venus;
    private GameObject earth;
    private GameObject mars;
    private GameObject jupiter;
    private GameObject saturn;
    private GameObject uranus;
    private GameObject neptune;
    private Vector3[] vSun;
    private Vector3[] vMercury;
    private Vector3[] vVenus;
    private Vector3[] vEarth;
    private Vector3[] vMars;
    private Vector3[] vJupiter;
    private Vector3[] vSaturn;
    private Vector3[] vUranus;
    private Vector3[] vNeptune;
    
    void Start()
    {
        rotY = 0f;

        sun = CreateGameObject(sun, Color.yellow);
        vSun = sun.GetComponent<MeshFilter>().mesh.vertices;
        mercury = CreateGameObject(mercury, Color.red);
        vMercury = mercury.GetComponent<MeshFilter>().mesh.vertices;
        venus = CreateGameObject(venus, new Color(255, 99, 71));
        vVenus = venus.GetComponent<MeshFilter>().mesh.vertices;
        earth = CreateGameObject(earth, Color.green);
        vEarth = earth.GetComponent<MeshFilter>().mesh.vertices;
        mars = CreateGameObject(mars, new Color(128, 64, 0));
        vMars = mars.GetComponent<MeshFilter>().mesh.vertices;
        jupiter = CreateGameObject(jupiter, Color.gray);
        vJupiter = jupiter.GetComponent<MeshFilter>().mesh.vertices;
        saturn = CreateGameObject(saturn, Color.white);
        vSaturn = saturn.GetComponent<MeshFilter>().mesh.vertices;
        uranus = CreateGameObject(uranus, Color.blue);
        vUranus = uranus.GetComponent<MeshFilter>().mesh.vertices;
        neptune = CreateGameObject(neptune, Color.black);
        vNeptune = neptune.GetComponent<MeshFilter>().mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        rotY += rotGlobalSpeed;
        UpdateGameObject(sun, vSun, 1, 0, 3);
        UpdateGameObject(mercury, vMercury, 1.1f, 1, 0.1f);
        UpdateGameObject(venus, vVenus, 1.3f, 1.5f, 0.3f);
        UpdateGameObject(earth, vEarth, 1.5f, 1.7f, 0.5f);
        UpdateGameObject(mars, vMars, 1.6f, 1.8f, 0.4f);
        UpdateGameObject(jupiter, vJupiter, 1.8f, 2.0f, 0.85f);
        UpdateGameObject(saturn, vSaturn, 2.1f, 2.2f, 0.6f);
        UpdateGameObject(uranus, vUranus, 2.4f, 2.6f, 0.45f);
        UpdateGameObject(neptune, vNeptune, 2.6f, 3.4f, 0.4f);
    }

    private GameObject CreateGameObject(GameObject planet, Color color)
    {
        planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planet.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        return planet;
    }

    private void UpdateGameObject(GameObject planet, Vector3[] v, float rotSpeed, float distance, float scale)
    {
        Matrix4x4 tr = Transformaciones.RotateY(rotY * rotSpeed);
        Matrix4x4 tm = Transformaciones.Translate(distance, 0, 0);
        Matrix4x4 ts = Transformaciones.Scale(scale, scale, scale);

        planet.GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(tr * tm * ts, v);
        planet.GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }
}
