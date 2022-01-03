using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip buttonClickAudioClip;
    public AudioClip screamAudioClip;
    
    public AudioSource audioSource;
    void Start()
    {
        
    }

    public void PlayButtonClickSound()
    {
        audioSource.clip = buttonClickAudioClip;
        audioSource.Play();
    }

    public void playScreamSound()
    {
        audioSource.clip = screamAudioClip;
        audioSource.Play();
    }

    public void stop()
    {
        audioSource.Stop();
    }
}
