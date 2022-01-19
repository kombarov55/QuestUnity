namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class ShieldStatusEffect : StatusEffect
    {
        public int BlockedAmount;

        public ShieldStatusEffect(int duration, string imagePath, int blockedAmount) : base(duration, imagePath, SpellActionType.Buff)
        {
            BlockedAmount = blockedAmount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer) 
            {
                stateManager.PlayerDamageBlocked.Value = BlockedAmount;
            }
            else
            {
                stateManager.EnemyDamageBlocked.Value = BlockedAmount;
            }
        }
    }
}