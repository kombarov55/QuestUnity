namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class BlockHealingStatusEffect : StatusEffect
    {
        public BlockHealingStatusEffect(int duration, string imagePath) : base(duration, imagePath)
        {
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.BlockHealingOnPlayer = true;
            }
            else
            {
                stateManager.BlockHealingOnEnemy = true;
            }
        }
    }
}