using Other.MatchThreeGame.Assets.Scripts.Service;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class SpellDamageAction : SpellAction
    {
        public int DamageAmount;
        
        public SpellDamageAction(int damageAmount) : base(SpellActionType.Damage)
        {
            DamageAmount = damageAmount;
        }
        
        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                StateAlterationService.DoDamageToPlayer(stateManager, DamageAmount);
            }
            else
            {
                StateAlterationService.DoDamageToEnemy(stateManager, DamageAmount);
            }
        }
    }
}