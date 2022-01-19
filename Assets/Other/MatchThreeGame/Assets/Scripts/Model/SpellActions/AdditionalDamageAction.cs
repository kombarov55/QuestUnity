﻿namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class AdditionalDamageAction : SpellAction
    {

        public int Amount;

        public AdditionalDamageAction(int amount) : base(SpellActionType.PositiveBuff)
        {
            Amount = amount;
        }

        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
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