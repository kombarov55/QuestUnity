﻿using System;
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
        private int _turnsLeft;
        private bool _isPlayersTurn = true;
        private int _playerHealthLeft;
        private int _enemyHealthLeft;
        private int _playerManaLeft;
        private int _enemyManaLeft;
        private int _coin;
        private bool _didCastInThisTurn = false;

        public List<RunningStatusEffect> StatusEffectsOnPlayer = new List<RunningStatusEffect>();
        public List<RunningStatusEffect> StatusEffectsOnEnemy = new List<RunningStatusEffect>();
        public int SequentialTurnsForPlayer = 1;
        public int SequentialTurnsForEnemy = 1;
        public int PlayerDamageBlocked = 0;
        public int EnemyDamageBlocked = 0;
        public bool ReflectDamageOnPlayer = false;
        public bool ReflectDamageOnEnemy = false;
        public bool BlockHealingOnPlayer = false;
        public bool BlockHealingOnEnemy = false;
        public int PlayerDamageAddition = 0;
        public int EnemyDamageAddition = 0;
        public int PlayerHealAddition = 0;
        public int EnemyHealAddition = 0;
        public int PlayerManaRestoreAddition = 0;
        public int EnemyManaRestoreAddition = 0;

        public int Score;

        public int TurnsLeft
        {
            get => _turnsLeft;
            set
            {
                _turnsLeft = value;
                foreach (var subscriber in OnTurnsLeftChangedSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }
        
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
                _turnsLeft = value.TurnsAmount;

                CoinCount = Prefs.CoinCount;
            }
        }

        public int PlayerHealthLeft
        {
            get => _playerHealthLeft;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                
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
                if (value < 0)
                {
                    value = 0;
                }
                
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
                if (value < 0)
                {
                    value = 0;
                }

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
                if (value < 0)
                {
                    value = 0;
                }
                
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
            set =>    _isPlayersTurn = value;
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
        
        public bool DidCastInThisTurn
        {
            get => _didCastInThisTurn;
            set
            {
                _didCastInThisTurn = value;
                
                foreach (var subscriber in OnDidCastInThisTurnSubscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }
        
        

        private List<Action<Level>> OnLevelInitializationSubscribers = new List<Action<Level>>();
        private List<Action<Level>> OnScoreChangedSubscribers = new List<Action<Level>>();
        private List<Action<int>> OnTurnsLeftChangedSubscribers = new List<Action<int>>();
        private List<Action<bool>> OnIsPlayersTurnSubscribers = new List<Action<bool>>();
        private List<Action<int>> OnPlayerHealthChangedSubscribers = new List<Action<int>>();
        private List<Action<int>> OnEnemyHealthChangedSubscribers = new List<Action<int>>();
        private List<Action<int>> OnPlayerManaChangedSubscribers = new List<Action<int>>();
        private List<Action<int>> OnEnemyManaChangedSubscribers = new List<Action<int>>();
        private List<Action<List<GameObject>>> OnCollapseSubscribers = new List<Action<List<GameObject>>>();
        private List<Action<int>> OnCoinCountChangedSubscribers = new List<Action<int>>();
        private List<Action<bool>> OnDidCastInThisTurnSubscribers = new List<Action<bool>>();
        private List<Action<int>> OnPlayerHealthDiffSubscribers = new List<Action<int>>();
        private List<Action<int>> OnEnemyHealthDiffSubscribers = new List<Action<int>>();
        private List<Action<int>> OnPlayerManaDiffSubscribers = new List<Action<int>>();
        private List<Action<int>> OnEnemyManaDiffSubscribers = new List<Action<int>>();
        
        public List<Action<RunningStatusEffect>> OnPlayerStatusEffectAddedSubscribers = new List<Action<RunningStatusEffect>>();
        public List<Action<RunningStatusEffect>> AfterPlayerStatusEffectTickSubscribers = new List<Action<RunningStatusEffect>>();
        public List<Action<RunningStatusEffect>> OnPlayerStatusEffectRemovedSubscribers = new List<Action<RunningStatusEffect>>();
        public List<Action<RunningStatusEffect>> OnEnemyStatusEffectAddedSubscribers = new List<Action<RunningStatusEffect>>();
        public List<Action<RunningStatusEffect>> AfterEnemyStatusEffectTickSubscribers = new List<Action<RunningStatusEffect>>();
        public List<Action<RunningStatusEffect>> OnEnemyStatusEffectRemovedSubscribers = new List<Action<RunningStatusEffect>>();


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
        
        public void SubscribeOnTurn(Action<int> action)
        {
            OnTurnsLeftChangedSubscribers.Add(action);
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

        public void SubscribeOnDidCastInThisTurn(Action<bool> action)
        {
            OnDidCastInThisTurnSubscribers.Add(action);
            action.Invoke(DidCastInThisTurn);
        }

        public void SubscribeOnPlayerHealthDiff(Action<int> action)
        {
            OnPlayerHealthDiffSubscribers.Add(action);
        }
        
        public void SubscribeOnEnemyHealthDiff(Action<int> action)
        {
            OnEnemyHealthDiffSubscribers.Add(action);
        }
        
        public void SubscribeOnPlayerManaDiff(Action<int> action)
        {
            OnPlayerManaDiffSubscribers.Add(action);
        }
        
        public void SubscribeOnEnemyManaDiff(Action<int> action)
        {
            OnEnemyManaDiffSubscribers.Add(action);
        }

        public void OnPlayerHealthChanged(int amount)
        {
            foreach (var subscriber in OnPlayerHealthDiffSubscribers)
            {
                subscriber.Invoke(amount);
            }
        }
        
        public void OnEnemyHealthChanged(int amount)
        {
            foreach (var subscriber in OnEnemyHealthDiffSubscribers)
            {
                subscriber.Invoke(amount);
            }
        }
        
        public void OnPlayerManaChanged(int amount)
        {
            foreach (var subscriber in OnPlayerManaDiffSubscribers)
            {
                subscriber.Invoke(amount);
            }
        }
        
        public void OnEnemyManaChanged(int amount)
        {
            foreach (var subscriber in OnEnemyManaDiffSubscribers)
            {
                subscriber.Invoke(amount);
            }
        }

        public void AddStatusEffectOnPlayer(StatusEffect statusEffect)
        {
            var runningStatusEffect = new RunningStatusEffect(statusEffect);
            StatusEffectsOnPlayer.Add(runningStatusEffect);
            foreach (var subscriber in OnPlayerStatusEffectAddedSubscribers)
            {
                subscriber.Invoke(runningStatusEffect);
            }
        }

        public void AfterStatusEffectTickOnPlayer(RunningStatusEffect runningStatusEffect)
        {
            foreach (var subscriber in AfterPlayerStatusEffectTickSubscribers)
            {
                subscriber.Invoke(runningStatusEffect);
            }
        }

        public void RemoveStatusEffectOnPlayer(RunningStatusEffect runningStatusEffect)
        {
            StatusEffectsOnPlayer.Remove(runningStatusEffect);
            foreach (var subscriber in OnPlayerStatusEffectRemovedSubscribers)
            {
                subscriber.Invoke(runningStatusEffect);
            }
        }
        
        public void AddStatusEffectOnEnemy(StatusEffect statusEffect)
        {
            var runningStatusEffect = new RunningStatusEffect(statusEffect);
            StatusEffectsOnEnemy.Add(runningStatusEffect);
            foreach (var subscriber in OnEnemyStatusEffectAddedSubscribers)
            {
                subscriber.Invoke(runningStatusEffect);
            }
        }

        public void AfterStatusEffectTickOnEnemy(RunningStatusEffect runningStatusEffect)
        {
            foreach (var subscriber in AfterEnemyStatusEffectTickSubscribers)
            {
                subscriber.Invoke(runningStatusEffect);
            }
        }

        public void RemoveStatusEffectOnEnemy(RunningStatusEffect runningStatusEffect)
        {
            StatusEffectsOnEnemy.Remove(runningStatusEffect);
            foreach (var subscriber in OnEnemyStatusEffectRemovedSubscribers)
            {
                subscriber.Invoke(runningStatusEffect);
            }
        }

        public void BeforeEnemyTurn()
        {
            SequentialTurnsForPlayer -= 1;
            if (SequentialTurnsForPlayer == 0)
            {
                IsPlayersTurn = false;

                foreach (var subscriber in OnIsPlayersTurnSubscribers)
                {
                    subscriber.Invoke(IsPlayersTurn);
                }
            } 
        }

        public void AfterEnemyTurn()
        {
            IsPlayersTurn = true;
            DidCastInThisTurn = false;
            SequentialTurnsForPlayer = 1;
            
            {
                foreach (var subscriber in OnIsPlayersTurnSubscribers)
                {
                    subscriber.Invoke(IsPlayersTurn);
                }
            }
        }
        
        public void ResetStats()
        {
            ReflectDamageOnEnemy = false;
            ReflectDamageOnPlayer = false;
            BlockHealingOnEnemy = false;
            BlockHealingOnPlayer = false;
            PlayerDamageAddition = 0;
            EnemyDamageAddition = 0;
            PlayerHealAddition = 0;
            EnemyHealAddition = 0;
            PlayerManaRestoreAddition = 0;
            EnemyManaRestoreAddition = 0;
        } 
    }
}