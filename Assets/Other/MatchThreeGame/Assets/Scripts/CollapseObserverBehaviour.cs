using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class CollapseObserverBehaviour : MonoBehaviour
    {
        private void Start()
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
            if (isPlayersTurn)
            {
                stateManager.EnemyHealthLeft -= 1;
            }
            else
            {
                stateManager.PlayerHealthLeft -= 1;                    
            }    
        }
        private void OnHeal(StateManager stateManager, bool isPlayersTurn) 
        {
            if (isPlayersTurn && stateManager.PlayerHealthLeft < stateManager.Level.PlayerHealth)
            {
                stateManager.PlayerHealthLeft += 1;
            }
            else if (stateManager.EnemyHealthLeft < stateManager.Level.EnemyHealth)
            {
                stateManager.EnemyHealthLeft += 1;
            }
        }
        
        private void OnCoin(StateManager stateManager, bool isPlayersTurn) 
        {
            Debug.Log("COIN");
        }
        
        private void OnMana(StateManager stateManager, bool isPlayersTurn) 
        {
            Debug.Log("MANA");
        }
    }

    enum CollapseType
    {
        Hit, Heal, Mana, Coin
    }
}