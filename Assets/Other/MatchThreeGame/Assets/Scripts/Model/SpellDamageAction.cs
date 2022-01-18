namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class SpellDamageAction : SpellAction
    {
        public int DamageAmount;
        
        public SpellDamageAction(int damageAmount)
        {
            ActionType = SpellActionType.Damage;
            DamageAmount = damageAmount;
        }
        
        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
            {
                stateManager.EnemyHealthLeft -= DamageAmount;
            }
            else
            {
                stateManager.PlayerHealthLeft -= DamageAmount;
            }
        }
    }
}