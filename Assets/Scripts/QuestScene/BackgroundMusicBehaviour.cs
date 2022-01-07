using UnityEngine;

namespace DefaultNamespace
{
    public class BackgroundMusicBehaviour : MonoBehaviour
    {

        public AudioSource audioSource;
        
        public void Pause()
        {
            audioSource.Pause();
        }
        
        public void Continue()
        {
            audioSource.Play();
        }
    }
}