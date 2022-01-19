namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class AdditionalDamageAction : SpellAction
    {

        public int Amount;

        public AdditionalDamageAction(int amount) : base(SpellActionType.PositiveBuff)
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