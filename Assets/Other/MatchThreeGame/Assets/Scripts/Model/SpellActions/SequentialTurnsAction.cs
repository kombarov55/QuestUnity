namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class SequentialTurnsAction : SpellAction
    {
        public int Amount;
        public bool IsForPlayer;

        public SequentialTurnsAction(int amount, bool isForPlayer) : base(SpellActionType.PositiveBuff)
        {
            Amount = amount;
            IsForPlayer = isForPlayer;
        }

        public override void Invoke(StateManager stateManager)
        {
            if (IsForPlayer)
            {
                stateManager.SequentialTurnsForPlayer = Amount;
            }
            else
            {
                stateManager.SequentialTurnsForEnemy = Amount;
            }

        }
    }
}