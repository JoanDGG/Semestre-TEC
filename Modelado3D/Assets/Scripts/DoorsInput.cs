using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsInput : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        door1.GetComponent<Animator>().SetBool("OpenDoor", Input.GetKeyDown(KeyCode.Alpha1));
        door2.GetComponent<Animator>().SetBool("OpenDoor", Input.GetKeyDown(KeyCode.Alpha2));
        door3.GetComponent<Animator>().SetBool("OpenDoor", Input.GetKeyDown(KeyCode.Alpha3));
    }
}
