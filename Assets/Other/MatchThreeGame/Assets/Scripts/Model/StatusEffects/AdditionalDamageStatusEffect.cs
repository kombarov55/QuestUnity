namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class AdditionalDamageStatusEffect : StatusEffect
    {
        public int Amount;

        public AdditionalDamageStatusEffect(int duration, string imagePath, int amount) : base(duration, imagePath, SpellActionType.PositiveBuff)
        {
            Amount = amount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.PlayerDamageAddition = Amount;
            }
            else
            {
                stateManager.EnemyDamageAddition = Amount;
            }
        }
    }
}