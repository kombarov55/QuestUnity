using System;
using System.Linq;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    public class SilenceStatusEffect : StatusEffect
    {
        public Func<Spell, bool> SpellSelector;

        public SilenceStatusEffect(int duration, string imagePath, Func<Spell, bool> spellSelector) : base(duration, imagePath, SpellActionType.Debuff)
        {
            SpellSelector = spellSelector;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.SilentedSpellsForPlayer = stateManager.Spells.Where(v => SpellSelector.Invoke(v)).ToList();
            }
            else
            {
                stateManager.SilentedSpellsForEnemy = stateManager.Spells.Where(v => SpellSelector.Invoke(v)).ToList();
            }
        }
    }
}