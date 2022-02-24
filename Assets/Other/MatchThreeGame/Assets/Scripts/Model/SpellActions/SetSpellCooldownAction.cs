using System;
using System.Linq;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
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
                var storedSpell = stateManager.StoredSpells.Find(v => SpellSelector.Invoke(v.Spell));

                if (storedSpell != null)
                {
                    storedSpell.TurnWhenUsed = int.MaxValue;
                }
            }
            else
            {
                //TODO??
            }
        }
    }
}