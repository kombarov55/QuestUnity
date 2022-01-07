using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ToastBehaviour : MonoBehaviour, IPointerClickHandler
    {

        [SerializeField] Text headerText;
        [SerializeField] Text paragraphText;
        [SerializeField] GameObject initialTextPosition;
        [SerializeField] GameObject targetTextPosition;

        private Action _onClickAction;

        public IEnumerator ShowWithFlyAway(string text, int delayInSeconds)
        {
            gameObject.SetActive(true);
            
            headerText.text = text;
            paragraphText.text = "";
            yield return new WaitForSeconds(delayInSeconds);
            
            headerText.transform.positionTo(0.4f, targetTextPosition.transform.position);
            yield return new WaitForSeconds(0.4f);
            
            gameObject.SetActive(false);
            
            headerText.transform.position = initialTextPosition.transform.position;
        }

        public void ShowUntilClicked(string text, string descriptionText, Action onClick)
        {
            gameObject.SetActive(true);
            
            headerText.text = text;
            paragraphText.text = descriptionText;

            _onClickAction = () =>
            {
                onClick.Invoke();
                gameObject.SetActive(false);
            };
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_onClickAction != null)
            {
                _onClickAction.Invoke();
            }
        }
    }
}