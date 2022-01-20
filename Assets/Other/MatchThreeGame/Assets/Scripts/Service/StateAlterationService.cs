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
                int damageDealt = damageAmount - stateManager.EnemyDamageBlocked.Value + stateManager.PlayerDamageAddition;

                stateManager.EnemyHealthLeft -= damageDealt;
                stateManager.EnemyDamageBlocked.Value = 0;
                stateManager.OnEnemyHealthChanged(-damageDealt);
            }
        }

        public static void HealPlayer(StateManager stateManager, int amount)
        {
            if (stateManager.PlayerHealthLeft == stateManager.Level.PlayerHealth)
            {
                return;
            }
            
            int healAmount = amount;

            if (stateManager.BlockHealingOnPlayer)
            {
                healAmount = 0;
            }
            else
            {
                healAmount = amount + stateManager.PlayerHealAddition;

                if (stateManager.PlayerHealthLeft + healAmount > stateManager.Level.PlayerHealth)
                {
                    healAmount = stateManager.Level.PlayerHealth - stateManager.PlayerHealthLeft;
                }
            }
            
            stateManager.PlayerHealthLeft += healAmount;
            stateManager.OnPlayerHealthChanged(healAmount);
        }
        
        public static void DoDamageToPlayer(StateManager stateManager, int damageAmount, bool wasReflected = false)
        {
            if (stateManager.IsDamageToPlayerReflected && !wasReflected)
            {
                DoDamageToEnemy(stateManager, damageAmount, true);
            }
            else
            {
                int damageDealt = damageAmount - stateManager.PlayerDamageBlocked.Value +
                                  stateManager.EnemyDamageAddition;

                stateManager.PlayerHealthLeft -= damageDealt;
                stateManager.PlayerDamageBlocked.Value = 0;
                stateManager.OnPlayerHealthChanged(-damageDealt);
            }
        }
        
        public static void HealEnemy(StateManager stateManager, int amount)
        {
            if (stateManager.EnemyHealthLeft == stateManager.Level.EnemyHealth)
            {
                return;
            }
            
            int healAmount = amount;

            if (stateManager.BlockHealingOnEnemy)
            {
                healAmount = 0;
            }
            else
            {
                healAmount = amount + stateManager.EnemyHealAddition;

                if (stateManager.EnemyHealthLeft + healAmount > stateManager.Level.EnemyHealth)
                {
                    healAmount = stateManager.Level.EnemyHealth - stateManager.EnemyHealthLeft;
                }
            }
            
            stateManager.EnemyHealthLeft += healAmount;
            stateManager.OnEnemyHealthChanged(healAmount);
        }

        public static void RestoreManaForPlayer(StateManager stateManager, int Amount)
        {
            if (stateManager.PlayerManaLeft < stateManager.Level.PlayerMana)
            {
                int manaRestoreAmount = Amount + stateManager.PlayerManaRestoreAddition;

                stateManager.PlayerManaLeft += manaRestoreAmount;
                stateManager.OnPlayerManaChanged(manaRestoreAmount);
            }
        }
        
        public static void RestoreManaForEnemy(StateManager stateManager, int Amount)
        {
            if (stateManager.EnemyManaLeft < stateManager.Level.EnemyMana) 
            {
                int manaRestoreAmount = Amount + stateManager.EnemyManaRestoreAddition;
                
                stateManager.EnemyManaLeft += manaRestoreAmount;
                stateManager.OnEnemyManaChanged(manaRestoreAmount);
            }
        }
    }
}