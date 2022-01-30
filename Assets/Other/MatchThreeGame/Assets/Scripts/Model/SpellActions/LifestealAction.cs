using System;
using Other.MatchThreeGame.Assets.Scripts.Service;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class LifestealAction : SpellAction
    {
        public int Amount;

        public LifestealAction(int amount) : base(SpellActionType.Damage)
        {
            Amount = amount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                StateAlterationService.DoDamageToPlayer(stateManager, Amount);
                StateAlterationService.HealEnemy(stateManager, Amount);
            }
            else
            {
                StateAlterationService.DoDamageToEnemy(stateManager, Amount);
                StateAlterationService.HealPlayer(stateManager, Amount);
            }
        }
    }
}