namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public static class StateAlterationService
    {
        
        public static void DoDamageToEnemy(StateManager stateManager, int damageAmount, bool wasReflected = false)
        {
            if (stateManager.IsDamageToEnemyReflected && !wasReflected)
            {
                DoDamageToPlayer(stateManager, damageAmount, true);
            }
            else
            {
                int damageDealt = damageAmount - stateManager.EnemyDamageBlocked + stateManager.PlayerDamageAddition;

                stateManager.EnemyHealthLeft -= damageDealt;
                stateManager.EnemyDamageBlocked = 0;
                stateManager.OnEnemyHealthChanged(-damageDealt);
            }
        }

        public static void HealOnPlayer(StateManager stateManager, int amount)
        {
            
        }
        
        public static void DoDamageToPlayer(StateManager stateManager, int damageAmount, bool wasReflected = false)
        {
            if (stateManager.IsDamageToPlayerReflected && !wasReflected)
            {
                DoDamageToEnemy(stateManager, damageAmount, true);
            }
            else
            {
                int damageDealt = damageAmount - stateManager.PlayerDamageBlocked +
                                  stateManager.EnemyDamageAddition;

                stateManager.PlayerHealthLeft -= damageDealt;
                stateManager.PlayerDamageBlocked = 0;
                stateManager.OnPlayerHealthChanged(-damageDealt);
            }
        }
        
        public static void HealOnEnemy(StateManager stateManager, int amount)
        {
            
        }
    }
}