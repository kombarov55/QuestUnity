﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class CurrentScoreTextBehaviour : MonoBehaviour
    {
        private void Start()
        {
            Text text = gameObject.GetComponent<Text>();
            StateManager stateManager = StateManager.Get();
            
            stateManager.SubscribeOnScoreChanged(level =>
            {
                text.text = stateManager.Score.ToString();
            });
        }
    }
}