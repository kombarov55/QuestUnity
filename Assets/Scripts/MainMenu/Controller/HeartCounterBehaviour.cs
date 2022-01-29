using System;
using DefaultNamespace;
using DefaultNamespace.Common;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Controller
{
    public class HeartCounterBehaviour : MonoBehaviour
    {

        private GlobalSerializedState _globalSerializedState;
        private string _subscriptionId;
        
        private void Start()
        {
            _globalSerializedState = GlobalSerializedState.Get();
            Text text = GetComponent<Text>();

            _subscriptionId = _globalSerializedState.ThreeInARowLifes.Subscribe(amount =>
            {
                text.text = "x " + amount;
            }, true);
        }

        private void OnDestroy()
        {
            _globalSerializedState.ThreeInARowLifes.Unsubscribe(_subscriptionId);
        }
    }
}