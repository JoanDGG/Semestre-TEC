using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float tiempoEspera = 2f;
    public float radioExplosion = 6f;
    public float fuerza = 500f;
    public GameObject explosionParticles;

    /*
    public float espera;
    bool exploto = false;
    public float radioEsplosion = 6f;
    public float fuerza = 500f;
    public gm explosion;

    start:
    espera = 2f;

    update:
    espera -= Time.deltaTime;
    if(espera <=0f && !exploto)
    {
        exploto = true;
        explotar();
    }

    explotar:
    Instantiate(explosion, transform.position, transform.rotation);
    Collider[] col = Physics.OverlapSphere(transform.position, radioExplosion);
    foreach(Collider cercano in col)
    {
        Rigidbody rb = cercano.GetComponent<Rigidbody>();
        if(rb != null)
            rb.AddExplosionForce(fuerza, transform.position, radioExplosion);
        Destroy(gameObject);
        Destroy(GameObject.Find("BigExplosionEffect(Clone)"), 3f);
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Explode", 0f, tiempoEspera);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Explode()
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
        Collider[] col = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach(Collider cercano in col)
        {
            Rigidbody rb = cercano.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddExplosionForce(fuerza, transform.position, radioExplosion);
            Destroy(gameObject);
            Destroy(GameObject.Find("BigExplosionEffect(Clone)"), 3f);
        }
    }
}
