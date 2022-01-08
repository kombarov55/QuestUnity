using System;
using System.Collections;
using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ToastBehaviour : MonoBehaviour
    {

        [SerializeField] Text headerText;
        [SerializeField] Text paragraphText;
        [SerializeField] GameObject targetTextPosition;
        
        private Vector3 _initialTextPosition;
        private Action _onClickAction;
        
        public IEnumerator ShowWithFlyAway(string text, int delayInSeconds)
        {
            return ShowWithFlyAway(text, "", delayInSeconds, () => { });
        }
        
        public IEnumerator ShowWithFlyAway(string text, Action then)
        {
            return ShowWithFlyAway(text, "", 2, then); 
        }

        public IEnumerator ShowGoals(Goal goal)
        {
            string s = GoalToString(goal);
            return ShowWithFlyAway(s, 2);
        }
        
        public IEnumerator ShowWithFlyAway(string text, string paragraph, int delayInSeconds, Action then)
        {
            gameObject.SetActive(true);
            
            headerText.text = text;
            paragraphText.text = paragraph;
            yield return new WaitForSeconds(delayInSeconds);

            _initialTextPosition = headerText.transform.position;
            headerText.transform.positionTo(0.4f, targetTextPosition.transform.position);
            yield return new WaitForSeconds(0.4f);
            
            gameObject.SetActive(false);
            
            headerText.transform.position = _initialTextPosition;
            
            then.Invoke();
        }

        private string GoalToString(Goal goal)
        {
            return "Наберите " + goal.Amount + " очков!";
        }
    }
}