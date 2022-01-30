using System;
using DefaultNamespace.Common;
using UnityEngine;
using UnityEngine.UI;

namespace QuestScene.Ui
{
    public class MoneyTextBehaviour : MonoBehaviour
    {
        private string _guid;
        private GlobalSerializedState _state;
        
        public void Start()
        {
            Text text = GetComponent<Text>();
            _state = GlobalSerializedState.Get();
            _guid = _state.CoinCount.Subscribe(v => text.text = "x" + v.ToString());
        }

        public void OnDestroy()
        {
            _state.CoinCount.Unsubscribe(_guid);
        }
    }
}