namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ManaburnAction : SpellAction
    {
        public int Amount;

        public ManaburnAction(int amount) : base(SpellActionType.Damage)
        {
            Amount = amount;
        }

        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
            {
                int manaAmount = stateManager.EnemyManaLeft - Amount <= 0 ? stateManager.EnemyManaLeft : Amount;
                
                stateManager.EnemyManaLeft -= manaAmount;
                stateManager.OnEnemyManaChanged(-manaAmount);
            }
            else
            {
                int manaAmount = stateManager.PlayerManaLeft - Amount <= 0 ? stateManager.PlayerManaLeft : Amount;
                
                stateManager.PlayerManaLeft -= manaAmount;
                stateManager.OnPlayerManaChanged(-manaAmount);
            }
        }
    }
}