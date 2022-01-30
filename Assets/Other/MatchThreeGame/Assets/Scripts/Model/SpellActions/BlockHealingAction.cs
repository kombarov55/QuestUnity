using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class BlockHealingAction : SpellAction
    {
        public BlockHealingAction() : base(SpellActionType.Debuff)
        {
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.BlockHealingOnPlayer = true;
            }
            else
            {
                stateManager.BlockHealingOnEnemy = true;
            }
        }
    }
}