using System;
using Other.MatchThreeGame.Assets.Scripts.Service;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class AddManaAction : SpellAction
    {
        public int ManaAmount;

        public AddManaAction(int manaAmount) : base(SpellActionType.Heal)
        {
            ManaAmount = manaAmount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                StateAlterationService.RestoreManaForPlayer(stateManager, ManaAmount);
            }
            else
            {
                StateAlterationService.RestoreManaForEnemy(stateManager, ManaAmount);
            }
        }
    }
}