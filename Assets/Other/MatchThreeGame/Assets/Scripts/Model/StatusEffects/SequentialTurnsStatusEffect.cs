namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class SequentialTurnsStatusEffect : StatusEffect
    {
        public int Amount;

        public SequentialTurnsStatusEffect(int duration, string imagePath, int amount) : base(duration, imagePath)
        {
            Amount = amount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.SequentialTurnsForPlayer = Amount;
            }
            else
            {
                stateManager.SequentialTurnsForEnemy = Amount;
            }
        }
    }
}