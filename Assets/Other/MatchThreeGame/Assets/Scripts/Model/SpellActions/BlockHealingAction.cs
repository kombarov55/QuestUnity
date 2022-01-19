namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class BlockHealingAction : SpellAction
    {
        public BlockHealingAction()
        {
            ActionType = SpellActionType.NegativeBuff;
        }

        public override void Invoke(StateManager stateManager)
        {
            if (stateManager.IsPlayersTurn)
            {
                stateManager.BlockHealingOnEnemy = true;
            }
            else
            {
                stateManager.BlockHealingOnPlayer = true;
            }
        }
    }
}