using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    public GameObject greenLight;
    new private Rigidbody rigidbody;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name.Contains("Example"))
        {
            animator.SetBool("Moving", Input.GetKey(KeyCode.Space));
        }
        else
        {
            animator.SetBool("Moving", greenLight.activeSelf);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            rigidbody.MovePosition(rigidbody.position +  Vector3.forward * 3.0f * Time.deltaTime);
        }
    }
}
