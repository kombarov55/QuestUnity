using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class AdditionalManaRestoreAction : SpellAction
    {
        public int Amount;

        public AdditionalManaRestoreAction(int amount) : base(SpellActionType.Heal)
        {
            Amount = amount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.PlayerManaRestoreAddition = Amount;
            }
            else
            {
                stateManager.EnemyManaRestoreAddition = Amount;
            }
        }
    }
}