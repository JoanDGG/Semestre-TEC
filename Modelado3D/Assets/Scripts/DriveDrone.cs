using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveDrone : MonoBehaviour
{
    public float turnVelocity = 6.0f;
    public float normalVelocity = 5.0f;
    private Rigidbody rigidbodyDrone;
    private Animator animatorDrone;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyDrone = GetComponent<Rigidbody>();
        animatorDrone = transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Right
        if(Input.GetAxis("Horizontal") > 0)
        {
            animatorDrone.SetFloat("RVelocity", Input.GetAxisRaw("Horizontal"));
            
            Vector3 eulerAngleVelocity = new Vector3(0, turnVelocity, 0);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
            rigidbodyDrone.MoveRotation(rigidbodyDrone.rotation * deltaRotation);
        }
        
        // Left
        if(Input.GetAxis("Horizontal") < 0)
        {
            animatorDrone.SetFloat("LVelocity", -Input.GetAxisRaw("Horizontal"));
            Vector3 eulerAngleVelocity = new Vector3(0, -turnVelocity, 0);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
            rigidbodyDrone.MoveRotation(rigidbodyDrone.rotation * deltaRotation);
        }
        
        // Forward
        if(Input.GetAxis("Vertical") > 0)
        {
            animatorDrone.SetFloat("FVelocity", Input.GetAxisRaw("Vertical"));
            rigidbodyDrone.MovePosition(transform.position +  transform.forward * normalVelocity * Time.deltaTime);
            print("----------------");
            print(transform.position);
            print(transform.forward);
            print(normalVelocity);
        }
    }
}
