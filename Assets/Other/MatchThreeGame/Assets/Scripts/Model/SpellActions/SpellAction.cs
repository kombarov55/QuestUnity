namespace Other.MatchThreeGame.Assets.Scripts.Model 
{

    public abstract class SpellAction
    {
        public SpellActionType ActionType;

        protected SpellAction(SpellActionType actionType)
        {
            ActionType = actionType;
        }

        public abstract void Cast(StateManager stateManager, bool isAffectedOnPlayer);
    }

}