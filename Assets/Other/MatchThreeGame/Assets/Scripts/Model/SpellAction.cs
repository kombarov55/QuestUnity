namespace Other.MatchThreeGame.Assets.Scripts.Model 
{

    public abstract class SpellAction
    {
        public SpellActionType ActionType;

        public abstract void Invoke(StateManager stateManager);
    }

}