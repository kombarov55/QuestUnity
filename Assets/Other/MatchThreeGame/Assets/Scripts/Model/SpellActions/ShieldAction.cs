using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{


    public class ShieldAction : SpellAction
    {
        public int Amount;

        public ShieldAction(int amount)
        {
            Amount = amount;
            ActionType = SpellActionType.PositiveBuff;
        }

        public override void Invoke(StateManager stateManager)
        {
            stateManager.PlayerDamageBlocked = Amount;
        }
    }
}