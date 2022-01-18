using System;
using System.Collections;
using DefaultNamespace.Common.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class FadingTextBehaviour : MonoBehaviour
    {

        public Color positiveColor;
        public Color negativeColor;
        
        public void Display(int diff, float duration, Vector2 destination)
        {
            var _text = GetComponent<Text>();

            _text.text = diff > 0 ? 
                "+" + diff :
                diff.ToString();

            if (diff > 0)
            {
                _text.color = positiveColor;
            }
            else
            {
                _text.color = negativeColor;
            }
            
            StartCoroutine(UICoroutines.FadeTextToZeroAlpha(_text, duration));
            gameObject.transform.positionTo(duration, destination);
            StartCoroutine(DestroyAfterTime(duration));
        }

        private IEnumerator DestroyAfterTime(float duration)
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}