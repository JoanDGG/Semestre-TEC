using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDisparo : MonoBehaviour
{
    public float velocidad;
    public float fuego;
    public GameObject impacto;
    public GameObject golpe;
    // Start is called before the first frame update
    void Start()
    {
        if(impacto != null)
        {
            var impactoVFX = Instantiate(impacto, transform.position, Quaternion.identity);
            impactoVFX.transform.forward = gameObject.transform.forward;
            var parImpacto = impactoVFX.GetComponent<ParticleSystem>();
            if(parImpacto != null)
            {
                Destroy(impactoVFX, parImpacto.main.duration);
            }
            else
            {
                var parImpactoHija = impactoVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(impactoVFX, parImpactoHija.main.duration);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(velocidad != 0)
        {
            transform.position += transform.forward * (velocidad * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        velocidad = 0;
        ContactPoint contactPoint = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
        Vector3 position = contactPoint.point;

        if(golpe != null)
        {
            var golpeVFX = Instantiate(golpe, position, rotation);
            var parGolpe = golpeVFX.GetComponent<ParticleSystem>();
            if(parGolpe != null)
            {
                Destroy(golpeVFX, parGolpe.main.duration);
            }
            else
            {
                var parGolpeHija = golpeVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(golpeVFX, parGolpeHija.main.duration);
            }
        }
    }
}
