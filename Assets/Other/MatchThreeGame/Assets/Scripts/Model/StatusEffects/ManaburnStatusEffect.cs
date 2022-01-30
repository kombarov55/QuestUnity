using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class ManaburnStatusEffect : StatusEffect
    {

        public int Amount;

        public ManaburnStatusEffect(int duration, int amount) : base(duration, "RpgPack/S_Ice03", SpellActionType.Damage)
        {
            Amount = amount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                int manaAmount = stateManager.PlayerManaLeft - Amount <= 0 ? stateManager.PlayerManaLeft : Amount;
                
                stateManager.PlayerManaLeft -= manaAmount;
                stateManager.OnPlayerManaChanged(-manaAmount);
            }
            else
            {
                int manaAmount = stateManager.EnemyManaLeft - Amount <= 0 ? stateManager.EnemyManaLeft : Amount;
                
                stateManager.EnemyManaLeft -= manaAmount;
                stateManager.OnEnemyManaChanged(-manaAmount);
            }
        }
    }
}