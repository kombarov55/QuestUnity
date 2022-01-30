using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class ManaburnAction : SpellAction
    {
        public int Amount;

        public ManaburnAction(int amount) : base(SpellActionType.Damage)
        {
            Amount = amount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
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