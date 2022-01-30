using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public List<AudioClip> buffSpellAudioClips;
    public List<AudioClip> debuffSpellAudioClips;
    public List<AudioClip> damageSpellAudioClips;
    public List<AudioClip> healingSpellAudioClips;
    public AudioClip attackAudioClip;
    public AudioClip healAudioClip;
    public AudioClip coinAudioClip;
    public AudioClip manaAudioClip;
    
    public AudioSource spellAudioSource;
    public AudioSource fishkaAudioSource;

    public void PlayBuffSpellSound()
    {
        PlayRandomSound(buffSpellAudioClips, spellAudioSource);
    }

    public void PlayHealingSpellSound()
    {
        PlayRandomSound(healingSpellAudioClips, spellAudioSource);
    }

    public void PlayDamageSpellSound()
    {
        PlayRandomSound(damageSpellAudioClips, spellAudioSource);
    }

    public void PlayDebuffSpellSound()
    {
        PlayRandomSound(debuffSpellAudioClips, spellAudioSource);
    }

    public void PlayAttackSound()
    {
        PlaySound(attackAudioClip, fishkaAudioSource);
    }
    
    public void PlayHealSound()
    {
        PlaySound(healAudioClip, fishkaAudioSource);
    }
    
    public void PlayCoinSound()
    {
        PlaySound(coinAudioClip, fishkaAudioSource);
    }
    
    public void PlayManaSound()
    {
        PlaySound(manaAudioClip, fishkaAudioSource);
    }
    
    public void PlaySound(string path)
    {
        fishkaAudioSource.PlayOneShot(Resources.Load<AudioClip>(path));
    }

    private void PlayRandomSound(List<AudioClip> audioClips, AudioSource audioSource)
    {
        var clip = audioClips[Random.Range(0, audioClips.Count - 1)];
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    private void PlaySound(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.PlayOneShot(audioClip);
    }
    
}
