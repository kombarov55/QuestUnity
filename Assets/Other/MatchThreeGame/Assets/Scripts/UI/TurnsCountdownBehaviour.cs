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
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.SubscribeOnLevelInitialized(level => text.text = level.TurnsLeft.ToString());
            stateManager.SubscribeOnTurn(amount => text.text = amount.ToString());
        }
    }
}