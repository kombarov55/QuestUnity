namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ReflectDamageAction : SpellAction
    {
        public ReflectDamageAction() : base(SpellActionType.NegativeBuff)
        {
        }

        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
            {
                stateManager.IsDamageToPlayerReflected = true;
                ActionType = SpellActionType.PositiveBuff;
            }
            else
            {
                stateManager.IsDamageToEnemyReflected = true;
            }
        }
    }
}