using System;
using System.Collections;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class GoalTextBehaviour : MonoBehaviour
    {

        public GameObject targetToMoveTo;
        
        private void Start()
        {

            StartCoroutine(FadeText());
        }

        private IEnumerator FadeText()
        {
            yield return new WaitForSeconds(2);
            gameObject.transform.positionTo(0.4f, targetToMoveTo.transform.position);
        }
    }
}