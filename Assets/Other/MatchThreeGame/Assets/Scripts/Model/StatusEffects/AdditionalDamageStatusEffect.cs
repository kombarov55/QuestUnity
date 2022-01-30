using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class AdditionalDamageStatusEffect : StatusEffect
    {
        public int Amount;

        public AdditionalDamageStatusEffect(int duration, int amount) : base(duration, "RpgPack/S_Sword16", SpellActionType.Buff)
        {
            Amount = amount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.PlayerDamageAddition = Amount;
            }
            else
            {
                stateManager.EnemyDamageAddition = Amount;
            }
        }
    }
}