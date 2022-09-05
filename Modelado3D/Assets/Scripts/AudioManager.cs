using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sonidos;
    new private AudioSource audio;
    
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void AudioSelect(int clip, float volume)
    {
        audio.Stop();
        audio.PlayOneShot(sonidos[clip], volume);
    }
}
