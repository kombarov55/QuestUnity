namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ReflectDamageAction : SpellAction
    {
        public ReflectDamageAction() : base(SpellActionType.PositiveBuff)
        {
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.IsDamageToPlayerReflected = true;
            }
            else
            {
                stateManager.IsDamageToEnemyReflected = true;
            }
        }
    }
}