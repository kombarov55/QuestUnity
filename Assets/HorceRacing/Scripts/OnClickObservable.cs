using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Scripts
{
    public class OnClickObservable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public Action onPointerDownAction;
        public Action onPointerUpAction;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (onPointerDownAction != null)
            {
                onPointerDownAction.Invoke();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (onPointerUpAction != null)
            {
                onPointerUpAction.Invoke();
            }
        }
    }
}