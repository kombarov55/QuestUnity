namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class AdditionalHealAction : SpellAction
    {
        public int Amount;

        public AdditionalHealAction(int amount) : base(SpellActionType.Buff)
        {
            Amount = amount;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.PlayerHealAddition = Amount;
            }
            else
            {
                stateManager.EnemyHealAddition = Amount;
            }
        }
    }
}