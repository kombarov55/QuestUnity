using System;
using System.Linq;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class SilenceStatusEffect : StatusEffect
    {
        public Func<Spell, bool> SpellSelector;

        public SilenceStatusEffect(int duration, Func<Spell, bool> spellSelector) : base(duration, "RpgPack/S_Shadow08", SpellActionType.Debuff)
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