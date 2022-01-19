namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class AdditionalHealAction : SpellAction
    {
        public int Amount;

        public AdditionalHealAction(int amount) : base(SpellActionType.PositiveBuff)
        {
            Amount = amount;
        }

        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
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