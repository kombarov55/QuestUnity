namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class AdditionalTurnAction : SpellAction
    {
        public int TurnsToAdd;

        public AdditionalTurnAction(int turnsToAdd) : base(SpellActionType.PositiveBuff)
        {
            TurnsToAdd = turnsToAdd;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            stateManager.TurnsLeft += TurnsToAdd;
        }
    }
}