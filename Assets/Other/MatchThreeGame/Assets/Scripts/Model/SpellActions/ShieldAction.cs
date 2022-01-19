using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ShieldAction : SpellAction
    {
        public int Amount;

        public ShieldAction(int amount) : base(SpellActionType.Buff)
        {
            Amount = amount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            stateManager.PlayerDamageBlocked = Amount;
        }
    }
}