﻿namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class ReflectDamageStatusEffect : StatusEffect
    {
        public ReflectDamageStatusEffect(int duration, string imagePath) : base(duration, imagePath, SpellActionType.PositiveBuff)
        {
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.ReflectDamageOnEnemy = true;
            }
            else
            {
                stateManager.ReflectDamageOnPlayer = true;
            }
        }
    }
}