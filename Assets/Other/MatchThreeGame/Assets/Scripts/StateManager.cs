using System;
using System.Collections.Generic;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class StateManager : MonoBehaviour
    {

        private float score;
        private int turnsLeft;
        
        private List<Action<float>> OnScoreChangedSubscribers = new List<Action<float>>();
        private List<Action<int>> OnTurnSubscribers = new List<Action<int>>();
        
        
        public void SubscribeOnScoreChanged(Action<float> onScoreChanged)
        {
            OnScoreChangedSubscribers.Add(onScoreChanged);
        }

        public void SubscribeOnTurn(Action<int> action)
        {
            OnTurnSubscribers.Add(action);
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

        public void TurnMade()
        {
            turnsLeft -= 1;
            
            foreach (var onTurnSubscriber in OnTurnSubscribers)
            {
                onTurnSubscriber.Invoke(turnsLeft);
            }
        }

        public void SetTurnsLeft(int amount)
        {
            turnsLeft = amount;
            
            foreach (var onTurnSubscriber in OnTurnSubscribers)
            {
                onTurnSubscriber.Invoke(turnsLeft);
            }            
        }
        
    }
}