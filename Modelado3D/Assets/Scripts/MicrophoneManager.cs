using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneManager : MonoBehaviour
{
    private AudioClip miClip;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            MicrophoneToAudioClip();
        else if(Input.GetKeyDown(KeyCode.F))
            PlayClip();
    }

    private void MicrophoneToAudioClip()
    {
        string micName = Microphone.devices[0];
        miClip = Microphone.Start(micName, true, 15, AudioSettings.outputSampleRate);
    }

    private void PlayClip()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(miClip);
    }
}
