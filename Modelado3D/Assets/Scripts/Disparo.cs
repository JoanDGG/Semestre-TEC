using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject puntoDisparo;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject efecto;
    [System.NonSerialized] public float tiempoDisparo = 0f;
    [System.NonSerialized] public bool banderaDisparo = false;
    
    void Start()
    {
        efecto = vfx[0];
    }

    void Update()
    {
        banderaDisparo = false;
        if(Input.GetKey(KeyCode.Space) && Time.time >= tiempoDisparo)
        {
            tiempoDisparo = Time.time + 1/ efecto.GetComponent<MovimientoDisparo>().fuego;
            banderaDisparo = true;
            mostrarVFX();
        }
    }

    private void mostrarVFX()
    {
        GameObject localVFX;
        if(puntoDisparo != null) { localVFX = Instantiate(efecto, puntoDisparo.transform.position, Quaternion.identity); }
    }
}
