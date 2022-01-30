using System;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.Common;
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
            _guid = GlobalState.LifesCountdownObservable.Subscribe(str => _text.text = str, true);
        }

        private void OnDestroy()
        {
            if (_guid != null)
            {
                GlobalState.LifesCountdownObservable.Unsubscribe(_guid);                
            }
        }
    }
}