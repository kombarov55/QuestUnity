namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class AdditionalTurnAction : SpellAction
    {
        public int TurnsToAdd;

        public AdditionalTurnAction(int turnsToAdd)
        {
            TurnsToAdd = turnsToAdd;
        }

        public override void Invoke(StateManager stateManager)
        {
            stateManager.TurnsLeft += TurnsToAdd;
        }
    }
}