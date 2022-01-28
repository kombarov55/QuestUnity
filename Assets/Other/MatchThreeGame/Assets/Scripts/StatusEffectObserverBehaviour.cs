using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class StatusEffectObserverBehaviour : MonoBehaviour
    {
        private void Start()
        {
            StateManager stateManager = StateManager.Get();
            
            stateManager.SubscribeOnIsPlayersTurn(isPlayersTurn =>
            {
                stateManager.ResetStats();
                
                if (isPlayersTurn)
                {
                    foreach (var runningStatusEffect in stateManager.StatusEffectsOnPlayer)
                    {
                        runningStatusEffect.TurnsLeft -= 1;
                        runningStatusEffect.StatusEffect.Tick(stateManager, true);
                        stateManager.AfterStatusEffectTickOnPlayer(runningStatusEffect);

                        if (runningStatusEffect.TurnsLeft == 0)
                        {
                            stateManager.RemoveStatusEffectOnPlayer(runningStatusEffect);
                        }
                    }
                }
                else
                {
                    foreach (var runningStatusEffect in stateManager.StatusEffectsOnEnemy)
                    {
                        runningStatusEffect.TurnsLeft -= 1;
                        runningStatusEffect.StatusEffect.Tick(stateManager, false);
                        stateManager.AfterStatusEffectTickOnEnemy(runningStatusEffect);

                        if (runningStatusEffect.TurnsLeft == 0)
                        {
                            stateManager.RemoveStatusEffectOnEnemy(runningStatusEffect);
                        }
                    }
                }
            });
        }
    }
}