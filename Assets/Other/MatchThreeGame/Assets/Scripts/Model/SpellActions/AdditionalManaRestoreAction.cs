namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class AdditionalManaRestoreAction : SpellAction
    {
        public int Amount;

        public AdditionalManaRestoreAction(int amount) : base(SpellActionType.Heal)
        {
            Amount = amount;
        }

        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
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