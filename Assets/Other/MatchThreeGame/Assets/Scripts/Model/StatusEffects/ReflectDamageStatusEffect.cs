﻿using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class ReflectDamageStatusEffect : StatusEffect
    {
        public ReflectDamageStatusEffect(int duration) : base(duration, "RpgPack/S_Shadow14", SpellActionType.Buff)
        {
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
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