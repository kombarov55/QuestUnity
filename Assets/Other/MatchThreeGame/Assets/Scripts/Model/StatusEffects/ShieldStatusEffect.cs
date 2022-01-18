namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class ShieldStatusEffect : StatusEffect
    {
        public int BlockedAmount;

        public ShieldStatusEffect(int duration, string imagePath, int blockedAmount) : base(duration, imagePath)
        {
            BlockedAmount = blockedAmount;
        }

        public override void Invoke(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer) 
            {
                stateManager.PlayerDamageBlocked = BlockedAmount;
            }
            else
            {
                stateManager.EnemyDamageBlocked = BlockedAmount;
            }
        }
    }
}