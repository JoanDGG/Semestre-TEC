using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionDisparo : MonoBehaviour
{
    private Animator animator;
    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bala.GetComponent<Disparo>().banderaDisparo)
        {
            animator.SetTrigger("Shoot");
        }
    }
}
