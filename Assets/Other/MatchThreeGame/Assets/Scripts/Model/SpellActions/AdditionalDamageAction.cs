using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class AdditionalDamageAction : SpellAction
    {

        public int Amount;

        public AdditionalDamageAction(int amount) : base(SpellActionType.Buff)
        {
            Amount = amount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
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