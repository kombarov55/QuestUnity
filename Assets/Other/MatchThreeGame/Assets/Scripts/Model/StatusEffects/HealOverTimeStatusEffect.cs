namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class HealOverTimeStatusEffect : StatusEffect
    {

        public int HealAmount;

        public HealOverTimeStatusEffect(int duration, int healAmount) : base(duration, "RpgPack/S_Poison06", SpellActionType.Heal)
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