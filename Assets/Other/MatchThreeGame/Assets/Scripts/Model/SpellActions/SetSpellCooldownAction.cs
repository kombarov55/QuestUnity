using System;
using System.Linq;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class SetSpellCooldownAction : SpellAction
    {
        public Func<Spell, bool> SpellSelector;
        public int CooldownAmountToSet;

        public SetSpellCooldownAction(Func<Spell, bool> spellSelector, int cooldownAmountToSet) : base(SpellActionType.Buff)
        {
            SpellSelector = spellSelector;
            CooldownAmountToSet = cooldownAmountToSet;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            if (isAffectedOnPlayer)
            {
                var spell = stateManager.SpellToCooldownObservable.Keys.ToList()
                    .Find(v => SpellSelector.Invoke(v));

                if (spell != null)
                {
                    stateManager.SpellToCooldownObservable[spell].Value = CooldownAmountToSet;
                }
            }
            else
            {
                //TODO??
            }
        }
    }
}