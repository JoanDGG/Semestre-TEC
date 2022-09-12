using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float asteroidSpeed = 3f;
    public float destinationSphereSize = 5f;
    public float asteroidLifeTime = 4f;

    private Vector3 destinationPosition;

    void Start()
    {
        Destroy(gameObject, asteroidLifeTime);
        destinationPosition = GameObject.FindGameObjectWithTag("Player").transform.position + Random.insideUnitSphere * destinationSphereSize;
    }

    void Update()
    {
        Vector3 direction = destinationPosition - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, asteroidSpeed * Time.deltaTime);
    }
}
