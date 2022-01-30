using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class AdditionalHealStatusEffect : StatusEffect
    {
        public int Amount;

        public AdditionalHealStatusEffect(int duration, int amount) : base(duration, "RpgPack/S_Poison03", SpellActionType.Buff)
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