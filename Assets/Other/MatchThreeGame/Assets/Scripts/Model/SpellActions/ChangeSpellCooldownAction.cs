using System;
using System.Collections.Generic;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ChangeSpellCooldownAction : SpellAction
    {
        public Func<List<Spell>, Spell> SpellSelector;

        public ChangeSpellCooldownAction(Func<List<Spell>, Spell> spellSelector) : base(SpellActionType.Buff)
        {
            SpellSelector = spellSelector;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            
        }
    }
}