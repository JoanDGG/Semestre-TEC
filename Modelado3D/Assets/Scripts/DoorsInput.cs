using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsInput : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    private bool door1Open;
    private bool door2Open;
    private bool door3Open;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            door1Open = !door1Open;
            audioManager.AudioSelect((door1Open ? 0 : 1), 0.5f);
            door1.GetComponent<Animator>().SetBool("OpenDoor", Input.GetKeyDown(KeyCode.Alpha1));
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            door2Open = !door2Open;
            audioManager.AudioSelect((door2Open ? 0 : 1), 0.5f);
            door2.GetComponent<Animator>().SetBool("OpenDoor", Input.GetKeyDown(KeyCode.Alpha2));
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            door3Open = !door3Open;
            audioManager.AudioSelect((door3Open ? 0 : 1), 0.5f);
            door3.GetComponent<Animator>().SetBool("OpenDoor", Input.GetKeyDown(KeyCode.Alpha3));
        }

    }
}
