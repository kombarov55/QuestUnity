using System;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class CurrentScoreTextBehaviour : MonoBehaviour
    {
        private void Start()
        {
            Text text = gameObject.GetComponent<Text>();
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.SubscribeOnScoreChanged(newValue =>
            {
                text.text = newValue.ToString();
            });
        }
    }
}