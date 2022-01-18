namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class HealOverTimeStatusEffect : StatusEffect
    {

        public int HealAmount;

        public HealOverTimeStatusEffect(int duration, string imagePath, int healAmount) : base(duration, imagePath)
        {
            HealAmount = healAmount;
        }

        public override void Invoke(StateManager stateManager, bool isOnPlayer)
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