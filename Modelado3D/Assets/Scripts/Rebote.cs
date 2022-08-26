using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    public float numPelotas = 100f;
    private GameObject pelotaInstancia;


    // Start is called before the first frame update
    void Start()
    {
        //CreateRandomSpheres();
        CreateShpere(transform.position, 1f, Color.cyan);     
    }

    void CreateRandomSpheres()
    {
        for (int i = 0; i < numPelotas; i++)
        {
            float px = Random.Range(-10.0f, 10.0f);
            float py = Random.Range(-10.0f, 10.0f);
            float pz = Random.Range(-10.0f, 10.0f);
            Vector3 p = new Vector3(px, py, pz);
            
            float s = Random.Range(0.5f, 5.0f);
            
            float cx = Random.Range(0.0f, 1.0f);
            float cy = Random.Range(0.0f, 1.0f);
            float cz = Random.Range(0.0f, 1.0f);
            Color c = new Color(cx, cy, cz);
            CreateShpere(p, s, c);
        }
    }
    GameObject CreateShpere(Vector3 position,  float scale, Color color)
    {
        pelotaInstancia = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pelotaInstancia.transform.localPosition = position;
        pelotaInstancia.transform.localScale = new Vector3(scale, scale, scale);

        Renderer renderer = pelotaInstancia.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.SetColor("_Color", color);

        Rigidbody rigidbody = pelotaInstancia.AddComponent<Rigidbody>();
        rigidbody.mass = 2;

        PhysicMaterial physicMaterial = new PhysicMaterial();
        physicMaterial.bounciness = 0.9f;
        Collider collider = pelotaInstancia.GetComponent<Collider>();
        collider.material = physicMaterial;

        StartCoroutine(FallRoutine(pelotaInstancia));
        
        return pelotaInstancia;
    }

    void Update()
    {

    }

    IEnumerator FallRoutine(GameObject pelota)
    {
        yield return new WaitUntil(() => pelota.transform.localPosition.y <= -25.0f);
        Destroy(pelota);
    }
}
