using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
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
        private int _playerHealthLeft;
        private int _enemyHealthLeft;
        private int _playerManaLeft;
        private int _enemyManaLeft;
        private int _coin;

        public int Score;
 
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

                PlayerHealthLeft = value.PlayerHealth;
                EnemyHealthLeft = value.EnemyHealth;
                PlayerManaLeft = 10;
                EnemyManaLeft = 10;

                CoinCount = Prefs.CoinCount;
            }
        }

        public int PlayerHealthLeft
        {
            get => _playerHealthLeft;
            set
            {
                _playerHealthLeft = value;
                foreach (var subscriber in OnPlayerHealthChangedSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }
        
        public int EnemyHealthLeft
        {
            get => _enemyHealthLeft;
            set
            {
                _enemyHealthLeft = value;
                foreach (var subscriber in OnEnemyHealthChangedSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }
        
        public int PlayerManaLeft
        {
            get => _playerManaLeft;
            set
            {
                _playerManaLeft = value;
                foreach (var subscriber in OnPlayerManaChangedSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }
        
        public int EnemyManaLeft
        {
            get => _enemyManaLeft;
            set
            {
                _enemyManaLeft = value;
                foreach (var subscriber in OnEnemyManaChangedSubscribers)
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

        public int CoinCount
        {
            get => _coin;
            set
            {
                _coin = value;
                Prefs.CoinCount = value;
                foreach (var subscriber in OnCoinCountChangedSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }
        
        

        private List<Action<Level>> OnLevelInitializationSubscribers = new List<Action<Level>>();
        private List<Action<Level>> OnScoreChangedSubscribers = new List<Action<Level>>();
        private List<Action<Level>> OnTurnSubscribers = new List<Action<Level>>();
        private List<Action<bool>> OnIsPlayersTurnSubscribers = new List<Action<bool>>();
        private List<Action<int>> OnPlayerHealthChangedSubscribers = new List<Action<int>>();
        private List<Action<int>> OnEnemyHealthChangedSubscribers = new List<Action<int>>();
        private List<Action<int>> OnPlayerManaChangedSubscribers = new List<Action<int>>();
        private List<Action<int>> OnEnemyManaChangedSubscribers = new List<Action<int>>();
        private List<Action<List<GameObject>>> OnCollapseSubscribers = new List<Action<List<GameObject>>>();
        private List<Action<int>> OnCoinCountChangedSubscribers = new List<Action<int>>();

        private void Start()
        {
            LevelService levelService = new LevelService();

            Level = levelService.GetCurrentLevel();
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
            Score = newValue;
            
            foreach (var subscriber in OnScoreChangedSubscribers)
            {
                subscriber.Invoke(_level);
            }
        }
        
        public void TurnMade()
        {
            Level.TurnsLeft -= 1;
            
            foreach (var onTurnSubscriber in OnTurnSubscribers)
            {
                onTurnSubscriber.Invoke(Level);
            }
        }

        public void SubscribeOnPlayerHealthChanged(Action<int> action)
        {
            OnPlayerHealthChangedSubscribers.Add(action);
            action.Invoke(_playerHealthLeft);
        }
        
        public void SubscribeOnEnemyHealthChanged(Action<int> action)
        {
            OnEnemyHealthChangedSubscribers.Add(action);
            action.Invoke(_enemyHealthLeft);
        }
        
        public void SubscribeOnPlayerManaChanged(Action<int> action)
        {
            OnPlayerManaChangedSubscribers.Add(action);
            action.Invoke(_playerManaLeft);
        }
        
        public void SubscribeOnEnemyManaChanged(Action<int> action)
        {
            OnEnemyManaChangedSubscribers.Add(action);
            action.Invoke(_enemyManaLeft);
        }

        public void SubscribeOnCollapse(Action<List<GameObject>> subscriber)
        {
            OnCollapseSubscribers.Add(subscriber);
        }

        public void OnCollapse(IEnumerable<GameObject> match)
        {
            var list = match.ToList();
            
            foreach (var subscriber in OnCollapseSubscribers)
            {
                subscriber.Invoke(list);
            }
        }

        public void SubscribeOnCoinCountChanged(Action<int> action)
        {
            OnCoinCountChangedSubscribers.Add(action);
            action.Invoke(_coin);
        }
    }
}