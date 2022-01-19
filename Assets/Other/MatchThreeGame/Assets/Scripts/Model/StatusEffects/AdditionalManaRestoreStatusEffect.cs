namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class AdditionalManaRestoreStatusEffect : StatusEffect
    {
        public int Amount;

        public AdditionalManaRestoreStatusEffect(int duration, string imagePath, int amount) : base(duration, imagePath, SpellActionType.PositiveBuff)
        {
            Amount = amount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.PlayerHealAddition = Amount;
            }
            else
            {
                stateManager.EnemyHealAddition = Amount;
            }
        }
    }
}