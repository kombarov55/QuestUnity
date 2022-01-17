using System;
using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Service;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class StateManager : MonoBehaviour
    {
        private Level _level;
        private GameState _gameGameState = GameState.None;
        private bool _isPlayersTurn = true;
        
        public Level Level
        {
            get => _level;
            set
            {
                _level = value;
                foreach (var subscriber in OnLevelInitializationSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }

        public GameState GameState 
        {
            get => _gameGameState;
            set => _gameGameState = value;
        }
        
        public bool IsPlayersTurn 
        {
            get => _isPlayersTurn;
            set
            {
                _isPlayersTurn = value;
                foreach (var subscriber in OnIsPlayersTurnSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }
        
        

        private List<Action<Level>> OnLevelInitializationSubscribers = new List<Action<Level>>();
        private List<Action<Level>> OnScoreChangedSubscribers = new List<Action<Level>>();
        private List<Action<Level>> OnTurnSubscribers = new List<Action<Level>>();
        private List<Action<bool>> OnIsPlayersTurnSubscribers = new List<Action<bool>>();

        private void Start()
        {
            GoalService goalService = new GoalService();

            Level = goalService.GetCurrentGoal();
        }


        public void SubscribeOnLevelInitialized(Action<Level> subscriber)
        {
            OnLevelInitializationSubscribers.Add(subscriber);
            if (_level != null)
            {
                subscriber.Invoke(_level);
            }
        }
        
        public void SubscribeOnTurn(Action<Level> action)
        {
            OnTurnSubscribers.Add(action);
        }

        public void SubscribeOnScoreChanged(Action<Level> subscriber)
        {
            OnScoreChangedSubscribers.Add(subscriber);
        }

        public void SubscribeOnIsPlayersTurn(Action<bool> subscriber)
        {
            OnIsPlayersTurnSubscribers.Add(subscriber);
            subscriber.Invoke(_isPlayersTurn);
        }

        public void SetScore(int newValue)
        {
            _level.Goals[0].CurrentAmount = newValue;
            
            foreach (var subscriber in OnScoreChangedSubscribers)
            {
                subscriber.Invoke(_level);
            }
        }

        public void IncreaseScore(int newValue)
        {
            SetScore(_level.Goals[0].CurrentAmount + newValue);
        }

        public void TurnMade()
        {
            Level.TurnsLeft -= 1;
            
            foreach (var onTurnSubscriber in OnTurnSubscribers)
            {
                onTurnSubscriber.Invoke(Level);
            }
        }
    }
}