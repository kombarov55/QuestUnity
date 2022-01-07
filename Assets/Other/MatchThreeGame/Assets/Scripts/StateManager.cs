using System;
using System.Collections.Generic;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class StateManager : MonoBehaviour
    {

        private float score;
        
        private List<Action<float>> OnScoreChangedSubscribers = new List<Action<float>>();
        
        
        public void SubscribeOnScoreChanged(Action<float> onScoreChanged)
        {
            OnScoreChangedSubscribers.Add(onScoreChanged);
        }

        public void SetScore(float newValue)
        {
            score = newValue;
            
            foreach (var subscriber in OnScoreChangedSubscribers)
            {
                subscriber.Invoke(newValue);
            }
        }

        public void IncreaseScore(float newValue)
        {
            SetScore(score + newValue);
        }
        
    }
}