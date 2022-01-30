using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class ShieldStatusEffect : StatusEffect
    {
        public int BlockedAmount;

        public ShieldStatusEffect(int duration, int blockedAmount) : base(duration, "RpgPack/E_Metal06", SpellActionType.Buff)
        {
            BlockedAmount = blockedAmount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer) 
            {
                stateManager.PlayerDamageBlocked.Value = BlockedAmount;
            }
            else
            {
                stateManager.EnemyDamageBlocked.Value = BlockedAmount;
            }
        }
    }
}