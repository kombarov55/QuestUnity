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
        public List<SpellAction> SpellActions;

        public Spell(string id, string name, string description, string imagePath, int manaCost, List<SpellAction> spellActions)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            ManaCost = manaCost;
            SpellActions = spellActions;
        }
    }
}