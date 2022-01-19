using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ShieldAction : SpellAction
    {
        public int BlockedAmount;

        public ShieldAction(int blockedAmount) : base(SpellActionType.Buff)
        {
            BlockedAmount = blockedAmount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.PlayerDamageBlocked.Value = BlockedAmount;                
            }
            else
            {
                //TODO
            }
            
        }
    }
}