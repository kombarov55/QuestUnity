﻿using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class StatusEffectObserverBehaviour : MonoBehaviour
    {
        private StateManager _stateManager;
        
        private void Start()
        {
            _stateManager = StateManager.Get();
            
            _stateManager.SubscribeOnIsPlayersTurn(isPlayersTurn =>
            {
                _stateManager.ResetStats();
                
                if (isPlayersTurn)
                {
                    foreach (var runningStatusEffect in _stateManager.StatusEffectsOnPlayer)
                    {
                        ApplyStatusEffect(runningStatusEffect, true);
                    }
                }
                else
                {
                    foreach (var runningStatusEffect in _stateManager.StatusEffectsOnEnemy)
                    {
                        ApplyStatusEffect(runningStatusEffect, false);
                    }
                }
            });
        }

        private void ApplyStatusEffect(RunningStatusEffect runningStatusEffect, bool isOnPlayer)
        {
            runningStatusEffect.StatusEffect.Tick(_stateManager, isOnPlayer);

            if (!runningStatusEffect.StatusEffect.IsPassive)
            {
                runningStatusEffect.TurnsLeft -= 1;
            }

            if (isOnPlayer)
            {
                _stateManager.AfterStatusEffectTickOnPlayer(runningStatusEffect);

                if (runningStatusEffect.TurnsLeft == 0)
                {
                    _stateManager.RemoveStatusEffectOnPlayer(runningStatusEffect);
                }                
            }
            else
            {
                _stateManager.AfterStatusEffectTickOnEnemy(runningStatusEffect);

                if (runningStatusEffect.TurnsLeft == 0)
                {
                    _stateManager.RemoveStatusEffectOnEnemy(runningStatusEffect);
                }                
            }
        }
    }
}