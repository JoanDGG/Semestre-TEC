using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public float spawnSphereSize = 5f;
    public GameObject[] asteroids;
    public Vector2 limitScale = new Vector2();

    void Start()
    {
        InvokeRepeating("Spawn", 0.5f, 1.0f);
    }

    void Spawn()
    {
        GameObject asteroid = Instantiate(  asteroids[Random.Range(0, asteroids.Length)], 
                                            transform.position + Random.insideUnitSphere * spawnSphereSize,
                                            Quaternion.identity);
        
        asteroid.transform.localScale *= Random.Range(limitScale.x, limitScale.y);
    }
}
