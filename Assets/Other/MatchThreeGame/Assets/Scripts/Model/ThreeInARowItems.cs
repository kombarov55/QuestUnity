using System.Collections.Generic;
using System.Linq;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public static class ThreeInARowItems
    {
        
        public static List<ThreeInARowItemTemplate> AllItemTemplates = new List<ThreeInARowItemTemplate>()
        {
            new ThreeInARowItemTemplate(
                "minor-health-potion",
                "Малое зелье здоровья",
                "Восстанавливает вам 2 хп",
                "RpgPack/P_Orange02",
                "Sounds/Sip",
                new List<SpellAction>()
                {
                    new HealAction(2)
                },
                new List<SpellAction>(),
                new List<StatusEffect>(),
                new List<StatusEffect>(),
                new List<StatusEffect>(),
                new List<StatusEffect>()
            ),
            new ThreeInARowItemTemplate(
                "minor-mana-potion",
                "Малое зелье маны",
                "Восстанавливает вам 2 маны",
                "RpgPack/P_Blue02",
                "Sounds/Sip",
                new List<SpellAction>()
                {
                    new AddManaAction(2)
                },
                new List<SpellAction>(),
                new List<StatusEffect>(),
                new List<StatusEffect>(),
                new List<StatusEffect>(),
                new List<StatusEffect>()
            ),
            new ThreeInARowItemTemplate(
                "minor-health-restoration-potion",
                "Малое зелье восстановления здоровья",
                "В течение 4х ходов вы будете восстанавливать по 5 единиц здоровья",
                "RpgPack/P_Orange02",
                "Sounds/Sip",
                new List<SpellAction>(),
                new List<SpellAction>(),
                new List<StatusEffect>()
                {
                    new HealOverTimeStatusEffect(4, 5)
                },
                new List<StatusEffect>(),
                new List<StatusEffect>(),
                new List<StatusEffect>()
            ),
            new ThreeInARowItemTemplate(
                "minor-poison-potion",
                "Слабый яд",
                "В течение 2х ходов враг будет получать по 3 урона",
                "RpgPack/S_Posion02",
                "Sounds/Sword",
                new List<SpellAction>(),
                new List<SpellAction>(),
                new List<StatusEffect>(),
                new List<StatusEffect>()
                {
                    new DamageOverTimeStatusEffect(2, 3)
                },
                new List<StatusEffect>(),
                new List<StatusEffect>()
            )
        };

        public static Dictionary<string, ThreeInARowItemTemplate> ItemIdToItemTemplate = AllItemTemplates.ToDictionary(v => v.Id, v => v);
    }
}