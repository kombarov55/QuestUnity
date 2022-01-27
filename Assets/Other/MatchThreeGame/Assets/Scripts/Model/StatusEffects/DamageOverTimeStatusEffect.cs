using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class DamageOverTimeStatusEffect : StatusEffect
    {
        public int DamageAmount;

        public DamageOverTimeStatusEffect(int duration, int damageAmount) : base(duration, "RpgPack/S_Fire02", SpellActionType.Damage)
        {
            DamageAmount = damageAmount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.PlayerHealthLeft -= DamageAmount;
                stateManager.OnPlayerHealthChanged(-DamageAmount);
            }
            else
            {
                stateManager.EnemyHealthLeft -= DamageAmount;
                stateManager.OnEnemyHealthChanged(-DamageAmount);
            }
        }
    }
}