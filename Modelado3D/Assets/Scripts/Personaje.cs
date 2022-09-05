using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private AudioManager audioManager;
    
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            audioManager.AudioSelect(0, 0.5f);
        if(Input.GetKeyDown(KeyCode.W))
            audioManager.AudioSelect(1, 0.5f);
    }
}
