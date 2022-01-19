using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    //crincle sound found here: http://freesound.org/people/volivieri/sounds/37171/

    public AudioClip crincleAudioClip;
    public List<AudioClip> buffSpellAudioClips;
    public List<AudioClip> debuffSpellAudioClips;
    public List<AudioClip> damageSpellAudioClips;
    public List<AudioClip> healingSpellAudioClips;
    
    AudioSource _crincle;
    AudioSource _spellAudioSource;

    void Awake()
    {
        _crincle = AddAudio();
        _spellAudioSource = AddAudio();
    }

    public void PlayCrincle()
    {
        _crincle.clip = crincleAudioClip;
        _crincle.Play();
    }

    public void PlayBuffSpellSound()
    {
        PlayRandomSound(buffSpellAudioClips, _spellAudioSource);
    }

    public void PlayHealingSpellSound()
    {
        PlayRandomSound(healingSpellAudioClips, _spellAudioSource);
    }

    public void PlayDamageSpellSound()
    {
        PlayRandomSound(damageSpellAudioClips, _spellAudioSource);
    }

    public void PlayDebuffSpellSound()
    {
        PlayRandomSound(debuffSpellAudioClips, _spellAudioSource);
    }
    
    
    private AudioSource AddAudio()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        return audioSource;
    }

    private void PlayRandomSound(List<AudioClip> audioClips, AudioSource audioSource)
    {
        var clip = audioClips[Random.Range(0, audioClips.Count - 1)];
        audioSource.clip = clip;
        audioSource.Play();
    }
    
}
