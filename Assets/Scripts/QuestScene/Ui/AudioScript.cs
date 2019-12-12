using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip buttonClickAudioClip;
    public AudioSource buttonClickAudioSource;
    void Start()
    {
        buttonClickAudioSource.clip = buttonClickAudioClip;
    }

    public void playButtonClickSound()
    {
        buttonClickAudioSource.Play();
    }
}
