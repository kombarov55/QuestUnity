using System.Collections.Generic;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class Spell
    {
        public string Id;
        public string Name;
        public string Description;
        public string ImagePath;
        public int ManaCost;
        public int Cooldown;
        public List<SpellAction> SpellActionsToSelf;
        public List<SpellAction> SpellActionsToEnemy;
        public List<StatusEffect> StatusEffectsOnSelf;
        public List<StatusEffect> StatusEffectsOnEnemy;

        public Spell(string id, string name, string description, string imagePath, int manaCost, int cooldown, List<SpellAction> spellActionsToSelf, List<SpellAction> spellActionsToEnemy, List<StatusEffect> statusEffectsOnSelf, List<StatusEffect> statusEffectsOnEnemy)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            ManaCost = manaCost;
            Cooldown = cooldown;
            SpellActionsToSelf = spellActionsToSelf;
            SpellActionsToEnemy = spellActionsToEnemy;
            StatusEffectsOnSelf = statusEffectsOnSelf;
            StatusEffectsOnEnemy = statusEffectsOnEnemy;
        }
    }
}