using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class AdditionalManaRestoreStatusEffect : StatusEffect
    {
        public int Amount;

        public AdditionalManaRestoreStatusEffect(int duration, int amount) : base(duration, "RpgPack/S_Buff10", SpellActionType.Buff)
        {
            Amount = amount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.PlayerHealAddition = Amount;
            }
            else
            {
                stateManager.EnemyHealAddition = Amount;
            }
        }
    }
}