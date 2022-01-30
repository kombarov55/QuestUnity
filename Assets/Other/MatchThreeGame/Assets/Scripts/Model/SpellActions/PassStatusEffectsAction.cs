using System;
using System.Linq;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class PassStatusEffectsAction : SpellAction
    {
        public Func<RunningStatusEffect, bool> StatusEffectSelector;
        
        public PassStatusEffectsAction(Func<RunningStatusEffect, bool> statusEffectSelector) : base(SpellActionType.Buff)
        {
            StatusEffectSelector = statusEffectSelector;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                var runningStatusEffects = stateManager.StatusEffectsOnEnemy.Where(v => StatusEffectSelector.Invoke(v)).ToList();
                foreach (var runningStatusEffect in runningStatusEffects)
                {
                    stateManager.RemoveStatusEffectOnEnemy(runningStatusEffect);
                    stateManager.AddStatusEffectOnPlayer(runningStatusEffect);
                }
            }
            else
            {
                var runningStatusEffects = stateManager.StatusEffectsOnPlayer.Where(v => StatusEffectSelector.Invoke(v)).ToList();
                foreach (var runningStatusEffect in runningStatusEffects)
                {
                    stateManager.RemoveStatusEffectOnPlayer(runningStatusEffect);
                    stateManager.AddStatusEffectOnEnemy(runningStatusEffect);
                }
            }
        }
    }
}