using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Controller
{
    public class HeartCounterBehaviour : MonoBehaviour
    {

        private string _subscriptionId;
        
        private void Start()
        {
            Text text = GetComponent<Text>();
            text.text = "x " + Prefs.ThreeInARowLifes;
            _subscriptionId = Prefs.SubscribeOnLifesChange(amount => text.text = "x " + amount);
        }

        private void OnDestroy()
        {
            Prefs.UnsubscribeOnLifesChange(_subscriptionId);
        }
    }
}