using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class OnClickComponent : MonoBehaviour, IPointerClickHandler
    {
        public Action action;
        public AudioScript audioScript;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (audioScript != null)
            {
                audioScript.PlayButtonClickSound();
            }

            InvokeOnClick();
        }

        protected void InvokeOnClick()
        {
            action.Invoke();
        }
    }
}