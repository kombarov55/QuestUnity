﻿namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class ShieldStatusEffect : StatusEffect
    {
        public int BlockedAmount;

        public ShieldStatusEffect(int duration, string imagePath, int blockedAmount) : base(duration, imagePath, SpellActionType.PositiveBuff)
        {
            BlockedAmount = blockedAmount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer) 
            {
                stateManager.PlayerDamageBlocked = BlockedAmount;
            }
            else
            {
                stateManager.EnemyDamageBlocked = BlockedAmount;
            }
        }
    }
}