namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class HealOverTimeStatusEffect : StatusEffect
    {

        public int HealAmount;

        public HealOverTimeStatusEffect(int duration, string imagePath, int healAmount) : base(duration, imagePath, SpellActionType.Heal)
        {
            HealAmount = healAmount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
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