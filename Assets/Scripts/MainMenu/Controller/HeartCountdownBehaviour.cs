using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Controller
{
    public class HeartCountdownBehaviour : MonoBehaviour
    {
    
        private Text _text;
        private string _guid;

        private void Start()
        {
            _text = GetComponent<Text>();

            if (Prefs.ThreeInARowLifes < GlobalConstants.MaxLifes)
            {
                _guid = Prefs.SubscribeOnLifesCountdown(text => _text.text = text);
            }
            else
            {
                _text.text = "00:00";
            }
        }

        private void OnDestroy()
        {
            if (_guid != null)
            {
                Prefs.UnsubscribeOnLifesChange(_guid);                
            }
        }
    }
}