using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class BlockHealingStatusEffect : StatusEffect
    {
        public BlockHealingStatusEffect(int duration) : base(duration, "RpgPack/S_Buff07", SpellActionType.Debuff)
        {
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.BlockHealingOnPlayer = true;
            }
            else
            {
                stateManager.BlockHealingOnEnemy = true;
            }
        }
    }
}