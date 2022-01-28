using System;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class TurnsCountdownBehaviour : MonoBehaviour
    {
        public void Start()
        {
            Text text = GetComponent<Text>();
            StateManager stateManager = StateManager.Get();
            
            stateManager.SubscribeOnLevelInitialized(level => text.text = level.TurnsLeft.ToString());
            stateManager.SubscribeOnTurn(amount => text.text = amount.ToString());
        }
    }
}