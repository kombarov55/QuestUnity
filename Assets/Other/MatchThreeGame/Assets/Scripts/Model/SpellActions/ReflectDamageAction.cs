using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class ReflectDamageAction : SpellAction
    {
        public ReflectDamageAction() : base(SpellActionType.Buff)
        {
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.IsDamageToPlayerReflected = true;
            }
            else
            {
                stateManager.IsDamageToEnemyReflected = true;
            }
        }
    }
}