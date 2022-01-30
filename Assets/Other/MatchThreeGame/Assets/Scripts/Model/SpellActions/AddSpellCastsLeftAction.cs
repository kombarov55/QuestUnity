using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class AddSpellCastsLeftAction : SpellAction
    {
        public int AmountToAdd;

        public AddSpellCastsLeftAction(int amountToAdd) : base(SpellActionType.Buff)
        {
            AmountToAdd = amountToAdd;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                stateManager.CastsLeftForPlayer.Value += AmountToAdd;
            }
            else
            {
                stateManager.CastsLeftForEnemy.Value += AmountToAdd;
            }
        }
    }
}