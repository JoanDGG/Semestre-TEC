using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;
    [Tooltip("\"Life Time\" is the time the object will dissapear")]
    public float lifeTime = 2f;

    public void FractureObject()
    {
        GameObject fracturedAsteroid = Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
        Destroy(fracturedAsteroid, lifeTime);
    }
}
