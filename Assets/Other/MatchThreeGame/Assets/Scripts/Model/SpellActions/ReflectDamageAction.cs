namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ReflectDamageAction : SpellAction
    {
        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
            {
                stateManager.ReflectDamageOnPlayer = true;
                ActionType = SpellActionType.PositiveBuff;
            }
            else
            {
                stateManager.ReflectDamageOnEnemy = true;
            }
        }
    }
}