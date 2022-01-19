using System;
using System.Collections.Generic;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class CollapseObserverBehaviour : MonoBehaviour
    {        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.SubscribeOnCollapse(match =>
            {
                var collapseType = DetermineCollapseType(match);

                switch (collapseType)
                {
                    case CollapseType.Hit: 
                        OnHit(stateManager, stateManager.IsPlayersTurn);
                        break;
                    case CollapseType.Heal: 
                        OnHeal(stateManager, stateManager.IsPlayersTurn);
                        break;
                    case CollapseType.Coin: 
                        OnCoin(stateManager, stateManager.IsPlayersTurn);
                        break;
                    case CollapseType.Mana: 
                        OnMana(stateManager, stateManager.IsPlayersTurn);
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
            if (isPlayersTurn && stateManager.ReflectDamageOnEnemy)
            {
                isPlayersTurn = false;
            }

            if (!isPlayersTurn && stateManager.ReflectDamageOnPlayer)
            {
                isPlayersTurn = true;
            }
        
            if (isPlayersTurn)
            {
                int damageDealt = Constants.Damage - stateManager.EnemyDamageBlocked + stateManager.PlayerDamageAddition;

                stateManager.EnemyHealthLeft -= damageDealt;
                stateManager.EnemyDamageBlocked = 0;
                stateManager.OnEnemyHealthChanged(-damageDealt);
            }
            else
            {
                int damageDealt = Constants.Damage - stateManager.PlayerDamageBlocked + stateManager.EnemyDamageAddition;
                
                stateManager.PlayerHealthLeft -= damageDealt;
                stateManager.PlayerDamageBlocked = 0;
                stateManager.OnPlayerHealthChanged(-damageDealt);
            }    
        }
        private void OnHeal(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn && stateManager.PlayerHealthLeft < stateManager.Level.PlayerHealth)
            {
                int healAmount = stateManager.BlockHealingOnPlayer ? 0 : Constants.Heal + stateManager.PlayerHealthRestoreAddition;
                
                stateManager.PlayerHealthLeft += healAmount;
                stateManager.OnPlayerHealthChanged(healAmount);
            }
            else if (stateManager.EnemyHealthLeft < stateManager.Level.EnemyHealth)
            {
                int healAmount = stateManager.BlockHealingOnEnemy ? 0 : Constants.Heal + stateManager.EnemyHealthRestoreAddition;
                
                stateManager.EnemyHealthLeft += healAmount;
                stateManager.OnEnemyHealthChanged(healAmount);
            }
        }
        
        private void OnCoin(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn)
            {
                stateManager.CoinCount += 1;
            }
        }
        
        private void OnMana(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn && stateManager.PlayerManaLeft < stateManager.Level.PlayerMana)
            {
                stateManager.PlayerManaLeft += 1;
                stateManager.OnPlayerManaChanged(1);
            } 
            else if (stateManager.EnemyManaLeft < stateManager.Level.EnemyMana)
            {
                stateManager.EnemyManaLeft += 1;
                stateManager.OnEnemyManaChanged(1);
            }
        }
    }

    enum CollapseType
    {
        Hit, Heal, Mana, Coin
    }
}