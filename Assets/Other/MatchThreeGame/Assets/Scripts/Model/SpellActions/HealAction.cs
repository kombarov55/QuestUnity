namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class HealAction : SpellAction
    {

        public int HealAmount;
        
        public HealAction(int healAmount) : base(SpellActionType.Heal)
        {
            HealAmount = healAmount;
        }
    
        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
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