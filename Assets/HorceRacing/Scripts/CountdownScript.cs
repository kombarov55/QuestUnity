using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Scripts
{
    public class CountdownScript : MonoBehaviour
    {
        public AudioSource countdownAudioSource;
        public AudioSource startedAudioSource;

        public void Start()
        {
            StartCoroutine(run());
        }
        
        public IEnumerator run()
        {
            var animator = GetComponent<Animator>();
            var text = GetComponent<Text>();

            text.text = "3";
            animator.enabled = true;
            startAnimation(animator);
            yield return new WaitForSeconds(1);
            
            text.text = "2";
            animator.enabled = true;
            startAnimation(animator);
            yield return new WaitForSeconds(1);
            
            text.text = "1";
            animator.enabled = true;
            startAnimation(animator);
            yield return new WaitForSeconds(1);
            
            text.text = "GO";
            animator.enabled = true;
            startAnimation(animator);
            yield return new WaitForSeconds(1);
        }

        private void startAnimation(Animator animator)
        {
            animator.enabled = true;
            animator.Play("CountdownAnimation", 0, 0f);
        }
    }
}