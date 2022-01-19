namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class BlockHealingAction : SpellAction
    {
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