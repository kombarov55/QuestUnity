using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ToastBehaviour : MonoBehaviour
    {

        [SerializeField] Text toastText;
        [SerializeField] GameObject initialTextPosition;
        [SerializeField] GameObject targetTextPosition;

        public IEnumerator ShowWithFlyAway(string text, int delayInSeconds)
        {
            gameObject.SetActive(true);
            
            toastText.text = text;
            toastText.transform.position = initialTextPosition.transform.position;
            yield return new WaitForSeconds(delayInSeconds);
            
            gameObject.transform.positionTo(0.4f, targetTextPosition.transform.position);
            yield return new WaitForSeconds(0.4f);
            
            gameObject.SetActive(false);
        }
    }
}