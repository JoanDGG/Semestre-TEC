using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4f;
    public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        print("A");
        if(other.gameObject.tag == "Asteroid")
        {
            print("Hit");
            // Destoy Asteroid
            other.gameObject.GetComponent<Fracture>().FractureObject();
        }
    }

}
