﻿using DefaultNamespace;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Service;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class EndGameObserverBehaviour : MonoBehaviour
    {
        public void Start()
        {
            SceneController sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
            StateManager stateManager = StateManager.Get();

            stateManager.SubscribeOnLevelInitialized(level =>
            {
                sceneController.ShowGoals(level);
            });
            
            stateManager.SubscribeOnPlayerHealthChanged(healthAmount =>
            {
                if (healthAmount <= 0)
                {
                    sceneController.ShowFailure();
                }
            });
            
            stateManager.SubscribeOnEnemyHealthChanged(healthAmount =>
            {
                if (healthAmount <= 0)
                {
                    sceneController.ShowVictory();
                }
            });
            
            stateManager.SubscribeOnTurn(amount =>
            {
                if (amount <= 0)
                {
                    sceneController.ShowFailure();
                }
            });
            
        }
    }
}