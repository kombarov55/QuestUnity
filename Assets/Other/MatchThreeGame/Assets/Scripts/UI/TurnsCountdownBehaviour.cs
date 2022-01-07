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
            
            stateManager.SubscribeOnTurn(turnsLeft => text.text = turnsLeft.ToString());
        }
    }
}