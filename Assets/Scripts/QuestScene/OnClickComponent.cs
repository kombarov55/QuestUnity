using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class OnClickComponent : MonoBehaviour, IPointerClickHandler
    {
        public Action action;

        public void OnPointerClick(PointerEventData eventData)
        {
            action.Invoke();
        }
    }
}