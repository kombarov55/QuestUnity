namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class SequentialTurnsAction : SpellAction
    {
        public int Amount;

        public SequentialTurnsAction(int amount) : base(SpellActionType.Buff)
        {
            Amount = amount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.SequentialTurnsForPlayer.Value += Amount;
            }
            else
            {
                stateManager.SequentialTurnsForEnemy.Value += Amount;
            }

        }
    }
}