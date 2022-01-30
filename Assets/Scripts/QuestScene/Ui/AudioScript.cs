using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip buttonClickAudioClip;
    public AudioClip screamAudioClip;
    public AudioClip coin1Clip;
    
    public AudioSource audioSource;

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

    public void PlayCoin1()
    {
        audioSource.PlayOneShot(coin1Clip);
    }

    public void stop()
    {
        audioSource.Stop();
    }
}
