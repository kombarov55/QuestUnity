namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class SpellHealAction : SpellAction
    {

        public int HealAmount;
        
        public SpellHealAction(int healAmount)
        {
            ActionType = SpellActionType.Heal;
            HealAmount = healAmount;
        }
    
        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
            {
                stateManager.PlayerHealthLeft += HealAmount;
                stateManager.OnPlayerHealthChanged(HealAmount);
            }
            else
            {
                stateManager.EnemyHealthLeft += HealAmount;
                stateManager.OnEnemyHealthChanged(HealAmount);
            }
        }
    }
}