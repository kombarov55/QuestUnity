namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class SpellDamageAction : SpellAction
    {
        public int DamageAmount;
        
        public SpellDamageAction(int damageAmount) : base(SpellActionType.Damage)
        {
            DamageAmount = damageAmount;
        }
        
        public override void Invoke(StateManager stateManager)
        {
            bool isPlayersTurn = stateManager.IsPlayersTurn;
            
            if (isPlayersTurn && stateManager.ReflectDamageOnEnemy)
            {
                isPlayersTurn = false;
            }

            if (!isPlayersTurn && stateManager.ReflectDamageOnPlayer)
            {
                isPlayersTurn = true;
            }

            if (isPlayersTurn)
            {
                stateManager.EnemyHealthLeft -= DamageAmount;
                stateManager.OnEnemyHealthChanged(-DamageAmount);
            }
            else
            {
                stateManager.PlayerHealthLeft -= DamageAmount;
                stateManager.OnPlayerHealthChanged(-DamageAmount);
            }
        }
    }
}