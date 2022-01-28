using System;
using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Service;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class CollapseObserverBehaviour : MonoBehaviour
    {
        private SoundManager _soundManager;
        
        private void Start()
        {
            StateManager stateManager = StateManager.Get();
            GameLifecycleObservables gameLifecycleObservables = stateManager.GameLifecycleObservables;
            _soundManager = stateManager.SoundManager;
            
            gameLifecycleObservables.OnCollapse.Subscribe(tuple =>
            {
                var (isPlayersTurn, match) = tuple;
                
                var collapseType = DetermineCollapseType(match);

                switch (collapseType)
                {
                    case CollapseType.Hit: 
                        OnHit(stateManager, isPlayersTurn);
                        break;
                    case CollapseType.Heal: 
                        OnHeal(stateManager, isPlayersTurn);
                        break;
                    case CollapseType.Coin: 
                        OnCoin(stateManager, isPlayersTurn);
                        break;
                    case CollapseType.Mana: 
                        OnMana(stateManager, isPlayersTurn);
                        break;
                }
            });
        }

        private CollapseType DetermineCollapseType(List<GameObject> match)
        {
            switch (match[0].GetComponent<Shape>().Type)
            {
                case "bean_purple": return CollapseType.Hit;
                case "bean_orange": return CollapseType.Coin;
                case "bean_blue": return CollapseType.Mana;
                case "bean_green": return CollapseType.Heal;
                default: throw new Exception("Invalid shape type");
            }
        }
        private void OnHit(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn)
            {
                StateAlterationService.DoDamageToEnemy(stateManager, Constants.Damage);
            } 
            else 
            {
                StateAlterationService.DoDamageToPlayer(stateManager, Constants.Damage);
            }
            
            _soundManager.PlayAttackSound();
        }
        private void OnHeal(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn)
            {
                StateAlterationService.HealPlayer(stateManager, Constants.Heal);
            }
            else
            {
                StateAlterationService.HealEnemy(stateManager, Constants.Heal);
            }
            
            _soundManager.PlayHealSound();
        }
        
        private void OnCoin(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn)
            {
                stateManager.CoinCount += 1;
            }
            
            _soundManager.PlayCoinSound();
        }
        
        private void OnMana(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn)
            {
                StateAlterationService.RestoreManaForPlayer(stateManager, Constants.Mana);
            } 
            else if (stateManager.EnemyManaLeft < stateManager.Level.EnemyMana)
            {
                StateAlterationService.RestoreManaForEnemy(stateManager, Constants.Mana);
            }
            
            _soundManager.PlayManaSound();
        }
    }

    enum CollapseType
    {
        Hit, Heal, Mana, Coin
    }
}